using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;
using Zetta.Server.Repositorios;

namespace Zetta.BD.DATA.REPOSITORY
{
    public class ItemPresupuestoRepositorio : Repositorio<ItemPresupuesto>, IItemPresupuestoRepositorio
    {
        private readonly Context _context;

        public ItemPresupuestoRepositorio(Context context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<ItemPresupuesto>> GetItemsPorNombreAsync(string nombre)
        {
            // Busca ítems cuyo nombre contenga el texto recibido (insensible a mayúsculas/minúsculas)
            return await _context.ItemPresupuestos
                .Where(ip => EF.Functions.Like(ip.Nombre.ToLower(), $"%{nombre.ToLower()}%"))
                .ToListAsync();
        }

        public async Task<List<ItemPresupuesto>> GetItemsPorRubroIdAsync(int rubroId)
        {
            // Busca ítems cuyo Rubro coincida con el valor recibido (por id de enum)
            return await _context.ItemPresupuestos
                .Where(ip => (int)ip.Rubro == rubroId)
                .ToListAsync();
        }

        public async Task<bool> ItemPresupuestoExisteAsync(int id)
        {
            // Verifica si existe un ítem con el id dado
            return await _context.ItemPresupuestos.AnyAsync(ip => ip.Id == id);
        }

        public async Task<ItemPresupuesto?> SelectById(int id)
        {
            // Devuelve el ítem con el id dado o null si no existe
            return await _context.ItemPresupuestos.FirstOrDefaultAsync(ip => ip.Id == id);
        }
    }
}

