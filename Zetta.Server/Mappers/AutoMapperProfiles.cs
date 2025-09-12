using AutoMapper;
using System.Text;
using Zetta.BD.DATA.ENTITY;
using Zetta.Shared.DTOS.Cliente;
using Zetta.Shared.DTOS.ItemPresupuesto;
using Zetta.Shared.DTOS.Presupuesto;
using Zetta.Shared.DTOS.PresItemDetalle;

namespace Zetta.Server.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // ======================= Cliente =======================
            CreateMap<Cliente, GET_ClienteDTO>();
            CreateMap<POST_ClienteDTO, Cliente>();
            CreateMap<PUT_ClienteDTO, Cliente>();

            // ======================= Presupuesto =======================
            // GET
            CreateMap<Presupuesto, GET_PresupuestoDTO>()
                .ForMember(dest => dest.Rubro, opt => opt.MapFrom(src => src.Rubro))
                .ForMember(dest => dest.OpcionDePago, opt => opt.MapFrom(src => src.OpcionDePago))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.ManodeObra, opt => opt.MapFrom(src => src.ManodeObra))
                .ForMember(dest => dest.Observacion, opt => opt.MapFrom(src => src.Observacion))
                .ForMember(dest => dest.TiempoAproxObra, opt => opt.MapFrom(src => src.TiempoAproxObra))
                .ForMember(dest => dest.TotalP, opt => opt.MapFrom(src => src.TotalP));

            // POST
            CreateMap<POST_PresupuestoDTO, Presupuesto>()
                .ForMember(dest => dest.Subtotal, opt => opt.Ignore());

            // PUT
            CreateMap<PUT_PresupuestoDTO, Presupuesto>()
                .ForMember(dest => dest.Subtotal, opt => opt.Ignore());


            // ======================= PresItemDetalle =======================
            CreateMap<POST_PresItemDetalleDTO, PresItemDetalle>();
            CreateMap<PUT_PresItemDetalleDTO, PresItemDetalle>();


            // ======================= ItemPresupuesto =======================
            CreateMap<ItemPresupuesto, GET_ItemPresupuestoDTO>();
            CreateMap<POST_ItemPresupuestoDTO, ItemPresupuesto>();
            CreateMap<PUT_ItemPresupuestoDTO, ItemPresupuesto>();
        }
    }
}