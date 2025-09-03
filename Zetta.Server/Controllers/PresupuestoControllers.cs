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


namespace SERVER.Controllers
{
    [ApiController]
    [Route("api/presupuestos")]
    public class PresupuestoController : ControllerBase
    {
        private readonly IPresupuestoRepositorio _presupuestoRepo;
        private readonly IMapper _mapper;
        private readonly Context _context;
        public PresupuestoController(Context context, IPresupuestoRepositorio presupuestoRepositorio, IMapper mapper)
        {
            _presupuestoRepo = presupuestoRepositorio;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<GET_PresupuestoDTO>> GetById(int id)
        {
            var presupuesto = await _presupuestoRepo.GetByIdAsync(id);
            if (presupuesto == null) return NotFound("No se encuentra el Cliente");

            var PresupuestoDTO = _mapper.Map<GET_PresupuestoDTO>(presupuesto);
            return Ok(PresupuestoDTO);
        }

        // POST: api/presupuesto
        [HttpPost]
        public async Task<ActionResult<int>> Post(POST_PresupuestoDTO dto)
        {
            try
            {
                Presupuesto entidad = _mapper.Map<Presupuesto>(dto);

                return await _presupuestoRepo.AddAsync(entidad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Método Update corregido para asegurar que todas las rutas devuelven un valor
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Presupuesto dto)
        {
            if (id != dto.Id) return BadRequest("El ID del presupuesto no coincide.");

            var presupuesto = await _presupuestoRepo.GetByIdAsync(id);
            if (presupuesto == null) return NotFound();

            presupuesto.Rubro = dto.Rubro;
            presupuesto.Aceptado = dto.Aceptado;
            presupuesto.Observacion = dto.Observacion;
            presupuesto.Total = dto.Total;
            presupuesto.ManodeObra = dto.ManodeObra;
            presupuesto.TotalP = dto.TotalP;
            presupuesto.TiempoAproxObra = dto.TiempoAproxObra;
            presupuesto.ValidacionDias = dto.ValidacionDias;
            presupuesto.OpcionDePago = dto.OpcionDePago;

            await _presupuestoRepo.UpdateAsync(presupuesto);

            return Ok("Presupuesto actualizado correctamente.");
        }

        // Reemplaza el bloque problemático en el método Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var presupuesto = await _presupuestoRepo.PresupuestoExisteAsync(id);
            if (!presupuesto)
                return NotFound($"Presupuesto {id} no encontrado.");

            await _presupuestoRepo.DeleteAsync(id);
            return Ok("Presupuesto eliminado correctamente.");
        }

        

    }
}

