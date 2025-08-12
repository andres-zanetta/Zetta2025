using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Zetta.BD.DATA.ENTITY;
using Zetta.Server.Repositorios;


namespace Zetta.BD.DATA.REPOSITORY
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        private readonly Context context;

        public ClienteRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
        public async Task<Cliente?>SearchByNameAsync(string nombre)
        {
            Cliente? zetta = await context.Clientes
                .FirstOrDefaultAsync(z => z.Nombre == nombre);

            return zetta;

        }

        public async Task<Cliente?> SelectByEmailAsync(string email)
        {
            Cliente? zetta = await context.Clientes.FirstOrDefaultAsync(c => c.Email == email);

            return zetta;
        }
    }
}
