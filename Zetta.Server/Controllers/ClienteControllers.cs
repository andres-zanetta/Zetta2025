using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;
using Zetta.BD.DATA.REPOSITORY;
using Zetta.Shared.DTOS.Cliente;


namespace Zetta.Server.Controllers
{
    [ApiController]
    [Route("/api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(Context context, IMapper mapper, IClienteRepositorio clienteRepositorio)
        {
            _context = context;
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<List<GET_ClienteDTO>>> Get()
        {
            var clientes = await _context.Clientes
                                         .Include(c => c.Presupuestos)
                                         .ToListAsync();

            var clientesDTO = _mapper.Map<List<GET_ClienteDTO>>(clientes);
            return Ok(clientesDTO);
        }

        // GET: api/clientes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GET_ClienteDTO>> GetById(int id)
        {
            var cliente = await _context.Clientes
                                        .Include(c => c.Presupuestos)
                                        .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                return NotFound("Cliente no encontrado.");

            var clienteDTO = _mapper.Map<GET_ClienteDTO>(cliente);
            return Ok(clienteDTO);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] POST_ClienteDTO dto)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(dto);
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return Ok(cliente.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/clientes/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PUT_ClienteDTO dto)
        {
            var dbCliente = await _context.Clientes.FindAsync(id);
            if (dbCliente == null)
                return NotFound("Cliente no encontrado.");

            _mapper.Map(dto, dbCliente);

            try
            {
                _context.Clientes.Update(dbCliente);
                await _context.SaveChangesAsync();
                return Ok("Cliente actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound("Cliente no encontrado.");

            try
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return Ok("Cliente eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


