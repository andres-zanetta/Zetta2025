using AutoMapper;
using System.Text;
using Zetta.BD.DATA.ENTITY;
using Zetta.Shared.DTOS.Cliente;
using Zetta.Shared.DTOS.ItemPresupuesto;
using Zetta.Shared.DTOS.Presupuesto;
using Zetta.Shared.DTOS.PresItemDetalle;
using Zetta.Shared.DTOS.Obra;

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

            // ======================= Obra =======================
            CreateMap<Obra, GET_ObraDTO>()
                .ForMember(dest => dest.EstadoObra, opt => opt.MapFrom(src => src.EstadoObra.ToString()))
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.Cliente.Id))
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.Cliente.Nombre))
                .ForMember(dest => dest.Comentarios, opt => opt.MapFrom(src => src.Comentarios != null ? src.Comentarios.Select(c => c.Texto).ToList() : null));
            
            CreateMap<POST_ObraDTO, Obra>()
                .ForMember(dest => dest.EstadoObra, opt => opt.MapFrom(src => Enum.Parse<EstadoObra>(src.EstadoObra)))
                .ForMember(dest => dest.Cliente, opt => opt.Ignore()) // Cliente se asignará en el servicio
                .ForMember(dest => dest.Comentarios, opt => opt.Ignore()) // Comentarios se manejarán por separado
                .ForMember(dest => dest.Presupuesto, opt => opt.Ignore()) // Presupuesto se asignará en el servicio
                .ForMember(dest => dest.PresupuestoId, opt => opt.MapFrom(src => src.PresupuestoId))
                .ForMember(dest => dest.FechaInicio, opt => opt.MapFrom(src => src.FechaInicio));

            CreateMap<PUT_ObraDTO, Obra>()
                .ForMember(dest => dest.EstadoObra, opt => opt.MapFrom(src => Enum.Parse<EstadoObra>(src.EstadoObra)))
                .ForMember(dest => dest.Cliente, opt => opt.Ignore()) 
                .ForMember(dest => dest.Comentarios, opt => opt.Ignore()) 
                .ForMember(dest => dest.Presupuesto, opt => opt.Ignore()) 
                .ForMember(dest => dest.FechaInicio, opt => opt.MapFrom(src => src.FechaInicio));

        }
    }
}