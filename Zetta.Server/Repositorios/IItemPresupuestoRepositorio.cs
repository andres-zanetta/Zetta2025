using Zetta.BD.DATA.ENTITY;
using Zetta.Server.Repositorios;

namespace Zetta.BD.DATA.REPOSITORY
{
    public interface IItemPresupuestoRepositorio : IRepositorio<ItemPresupuesto>
    {
        Task<List<ItemPresupuesto>> SelectAllAsync();
        Task<ItemPresupuesto?> SelectById(int id);
        Task<int> Insert(ItemPresupuesto entity);
        Task<bool> ItemPresupuestoExisteAsync(int id);
        Task<List<ItemPresupuesto>> GetItemsPorRubroIdAsync(int rubroId);
        Task<List<ItemPresupuesto>> GetItemsPorNombreAsync(string nombre);

    }
}