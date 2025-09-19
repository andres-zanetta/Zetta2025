using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;
using Zetta.BD.DATA.REPOSITORY;
using Zetta.Shared.DTOS.ItemPresupuesto;

namespace Zetta.SERVER.Controllers
{
    [ApiController]
    [Route("api/itempresupuesto")]
    public class ItemPresupuestoController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IItemPresupuestoRepositorio _itemPresupuestoRepositorio;

        public ItemPresupuestoController(IItemPresupuestoRepositorio repositorio, Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ItemPresupuesto
        [HttpGet]
        public async Task<ActionResult<List<GET_ItemPresupuestoDTO>>> Get()
        {
            var items = await _itemPresupuestoRepositorio.GetAllAsync();
            var itemsDTO = _mapper.Map<List<GET_ItemPresupuestoDTO>>(items);
            return Ok(itemsDTO);
        }

        // GET: api/ItemPresupuesto/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GET_ItemPresupuestoDTO>> GetById(int id)
        {
            var item = await _itemPresupuestoRepositorio.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound("No se encontró el ítem con ese ID.");
            }
            var itemDTO = _mapper.Map<GET_ItemPresupuestoDTO>(item);
            return Ok(itemDTO);
        }

        // POST: api/ItemPresupuesto
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] POST_ItemPresupuestoDTO dto)
        {
            try
            {
                var item = _mapper.Map<ItemPresupuesto>(dto);
                var id = await _itemPresupuestoRepositorio.AddAsync(item);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/ItemPresupuesto/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PUT_ItemPresupuestoDTO dto)
        {
            var item = await _itemPresupuestoRepositorio.GetByIdAsync(id);
            if (item == null)
                return NotFound("No se encontró el ítem.");

            _mapper.Map(dto, item);

            try
            {
                await _itemPresupuestoRepositorio.UpdateAsync(item);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ItemPresupuesto/{id}
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _itemPresupuestoRepositorio.GetByIdAsync(id);

            if (item == null)
                return NotFound("No se encontró el ítem con ese ID.");

            try
            {
                await _itemPresupuestoRepositorio.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest($"Error al eliminar el ítem: {e.Message}");
            }
        }
    }
}