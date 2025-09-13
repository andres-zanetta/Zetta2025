using AutoMapper;
using Zetta.BD.DATA.ENTITY;
using Microsoft.AspNetCore.Mvc;
using SERVER.Repositorio;
using Zetta.Shared.DTOS;
using Zetta.BD.DATA;
using Zetta.BD.DATA.REPOSITORY;
using Zetta.Server.Repositorios;
using Zetta.Shared.DTOS.Presupuesto;
using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA.ENTITY;
using Zetta.Shared.DTOS.PresItemDetalle;

namespace SERVER.Controllers
{
    [ApiController]
    [Route("api/presupuestos")]
    public class PresupuestoController : ControllerBase
    {
        private readonly IPresupuestoRepositorio _presupuestoRepo;
        private readonly IItemPresupuestoRepositorio _itemPresupuestoRepo;
        private readonly IMapper _mapper;
        private readonly Context _context;

        public PresupuestoController(Context context, IPresupuestoRepositorio presupuestoRepositorio, IItemPresupuestoRepositorio itemPresupuestoRepositorio, IMapper mapper)
        {
            _presupuestoRepo = presupuestoRepositorio;
            _itemPresupuestoRepo = itemPresupuestoRepositorio;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/presupuesto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GET_PresupuestoDTO>>> GetAll()
        {
            var presupuestos = await _presupuestoRepo.SelectAllAsync();
            return Ok(_mapper.Map<IEnumerable<GET_PresupuestoDTO>>(presupuestos));
        }

        // GET: api/presupuesto/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GET_PresupuestoDTO>> GetById(int id)
        {
            var presupuesto = await _presupuestoRepo.GetPresupuestoConDetallesPorIdAsync(id);
            if (presupuesto == null)
            {
                return NotFound($"Presupuesto con ID {id} no encontrado.");
            }
            return Ok(_mapper.Map<GET_PresupuestoDTO>(presupuesto));
        }

        // POST: api/presupuestos
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] POST_PresupuestoDTO dto)
        {
            try
            {
                // Mapeo inicial de los datos básicos del presupuesto
                var presupuesto = _mapper.Map<Presupuesto>(dto);

                // Manejo de los ítems de detalle
                if (dto.ItemsDetalle != null && dto.ItemsDetalle.Any())
                {
                    foreach (var itemDto in dto.ItemsDetalle)
                    {
                        var itemPresupuesto = await _context.ItemPresupuestos.FindAsync(itemDto.ItemPresupuestoId);
                        if (itemPresupuesto == null)
                        {
                            return BadRequest($"No se encontró el ítem del catálogo con ID: {itemDto.ItemPresupuestoId}");
                        }
                        var presItemDetalle = new PresItemDetalle
                        {
                            ItemPresupuestoId = itemDto.ItemPresupuestoId,
                            Cantidad = itemDto.Cantidad,
                            PrecioUnitario = itemDto.PrecioUnitario
                        };
                        presupuesto.ItemsDetalle.Add(presItemDetalle);
                    }
                }

                _context.Presupuestos.Add(presupuesto);
                await _context.SaveChangesAsync();

                return Ok(presupuesto.Id);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el presupuesto: {ex.Message}");
            }
        }

        // PUT: api/presupuestos/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] PUT_PresupuestoDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("El ID del presupuesto en la URL no coincide con el ID del cuerpo de la solicitud.");
            }

            var presupuestoExistente = await _context.Presupuestos
                .Include(p => p.ItemsDetalle)
                .ThenInclude(d => d.ItemPresupuesto)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (presupuestoExistente == null)
            {
                return NotFound($"Presupuesto con ID {id} no encontrado.");
            }

            // Mapeo de propiedades simples
            _mapper.Map(dto, presupuestoExistente);

            // Manejo de la colección ItemsDetalle
            if (dto.ItemsDetalle != null)
            {
                // Eliminar ítems que no están en el DTO
                var itemsParaEliminar = presupuestoExistente.ItemsDetalle
                    .Where(item => !dto.ItemsDetalle.Any(dtoItem => dtoItem.Id == item.Id))
                    .ToList();
                _context.PresItemDetalles.RemoveRange(itemsParaEliminar);

                // Añadir o actualizar ítems
                foreach (var itemDto in dto.ItemsDetalle)
                {
                    var itemExistente = presupuestoExistente.ItemsDetalle
                        .FirstOrDefault(item => item.Id == itemDto.Id);

                    if (itemExistente != null)
                    {
                        // Actualizar
                        itemExistente.Cantidad = itemDto.Cantidad;
                        itemExistente.PrecioUnitario = itemDto.PrecioUnitario;
                    }
                    else
                    {
                        // Añadir
                        var nuevoItem = _mapper.Map<PresItemDetalle>(itemDto);
                        presupuestoExistente.ItemsDetalle.Add(nuevoItem);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return Ok("Presupuesto actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var presupuesto = await _presupuestoRepo.PresupuestoExisteAsync(id);
            if (!presupuesto)
            {
                return NotFound($"Presupuesto {id} no encontrado.");
            }

            try
            {
                await _presupuestoRepo.DeleteAsync(id);
                return Ok("Presupuesto eliminado correctamente.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}