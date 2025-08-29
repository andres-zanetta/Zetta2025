using AutoMapper;
using Zetta.BD.DATA.ENTITY;
using Zetta.Shared.DTOS.Cliente;
using Zetta.Shared.DTOS.ItemPresupuesto;
using Zetta.Shared.DTOS.Presupuesto; // Asegúrate de tener este 'using'

namespace Zetta.Server.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // ======================= Cliente =======================
            // GET
            CreateMap<Cliente, GET_ClienteDTO>();

            // POST
            CreateMap<POST_ClienteDTO, Cliente>();

            // PUT
            CreateMap<PUT_ClienteDTO, Cliente>();

            // ======================= Presupuesto =======================
            // GET
            CreateMap<Presupuesto, GET_PresupuestoDTO>();

            // POST
            CreateMap<POST_PresupuestoDTO, Presupuesto>();

            // PUT
            CreateMap<PUT_PresupuestoDTO, Presupuesto>();

            //===================== ItemPresupuesto =======================
            CreateMap<ItemPresupuesto, GET_ItemPresupuestoDTO>();

            CreateMap<POST_ItemPresupuestoDTO, ItemPresupuesto>();

            CreateMap<PUT_ItemPresupuestoDTO, ItemPresupuesto>();

            // ======================= (Acá vas agregando más entidades/DTOs en el futuro) =======================
        }
    }
}