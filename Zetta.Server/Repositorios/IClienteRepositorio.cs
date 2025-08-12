using Zetta.BD.DATA.ENTITY;
using Zetta.Server.Repositorios;

namespace Zetta.BD.DATA.REPOSITORY
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Task<Cliente>SearchByNameAsync(string name);
        Task<Cliente> SelectByEmailAsync(string email);
    }
}
