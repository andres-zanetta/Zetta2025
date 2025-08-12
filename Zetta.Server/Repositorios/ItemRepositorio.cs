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

        
       
        

        
    }
}

