using Zetta.BD.DATA.ENTITY;
using Zetta.Server.Repositorios;

namespace SERVER.Repositorio
{
    public interface IObraRepositorio : IRepositorio<Obra>
    {
        Task<IEnumerable<Obra>> ObtenerObrasConDetallesAsync();
        Task<Obra?> ObtenerObraPorIdConDetallesAsync(int id);
        Task<IEnumerable<Obra>> ObtenerObrasPorEstadoAsync(EstadoObra estado);
        Task<IEnumerable<Obra>> ObtenerObrasPorClienteAsync(int clienteId);
    }
}