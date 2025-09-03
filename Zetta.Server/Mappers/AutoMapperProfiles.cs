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
            CreateMap<Presupuesto, GET_PresupuestoDTO>().ForMember(dest => dest.Rubro, opt => opt.MapFrom(src => src.Rubro))
                .ForMember(dest => dest.OpcionDePago, opt => opt.MapFrom(src => src.OpcionDePago))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => $"{src.Total}"))
                .ForMember(dest => dest.ManodeObra, opt => opt.MapFrom(src => src.ManodeObra))
                .ForMember(dest => dest.Observacion, opt =>opt.MapFrom(src => src.Observacion))
                .ForMember(dest => dest.TiempoAproxObra, opt => opt.MapFrom(src => src.TiempoAproxObra))
                .ForMember(dest => dest.TotalP, opt => opt.MapFrom(src => $"{src.TotalP}"));



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