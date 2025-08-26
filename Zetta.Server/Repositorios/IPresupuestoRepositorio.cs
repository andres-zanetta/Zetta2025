using Zetta.BD.DATA.ENTITY;

namespace Zetta.Server.Repositorios
{
    public interface IPresupuestoRepositorio:IRepositorio<Presupuesto>

    {
        Task<IEnumerable<Presupuesto>> GetPresupuestosConDetallesAsync();

        Task<Presupuesto?> GetPresupuestoConDetallesPorIdAsync(int id);

        Task<IEnumerable<Presupuesto>> GetPresupuestosPorClienteIdAsync(int clienteId);

        Task<IEnumerable<Presupuesto>> GetPresupuestosPorEstadoAsync(string estado);

        Task<bool> PresupuestoExisteAsync(int id);

        Task<List<Presupuesto>> SelectAllAsync();


    }
}