using AutoMapper;
using System.Text;
using Zetta.BD.DATA.ENTITY;
using Zetta.Shared.DTOS.Cliente;
using Zetta.Shared.DTOS.ItemPresupuesto;
using Zetta.Shared.DTOS.Obra;
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

            //===================== Obra =======================

            CreateMap<Obra, GET_ObraDTO>()
               .ForMember(dest => dest.EstadoObra, opt => opt.MapFrom(src => src.EstadoObra.ToString()))
               .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.Cliente.Id))
               .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.Cliente.Nombre)) // suponiendo que Cliente tiene Nombre
               .ForMember(dest => dest.Comentarios, opt => opt.MapFrom(src => src.Comentarios.Select(c => c.Texto).ToList()));

            CreateMap<POST_ObraDTO, Obra>()
               .ForMember(dest => dest.EstadoObra, opt => opt.MapFrom(src => Enum.Parse<EstadoObra>(src.EstadoObra)))
               .ForMember(dest => dest.Cliente, opt => opt.Ignore()); // Cliente se carga con el repositorio

            CreateMap<PUT_ObraDTO, Obra>()
               .ForMember(dest => dest.EstadoObra, opt => opt.MapFrom(src => Enum.Parse<EstadoObra>(src.EstadoObra)))
               .ForMember(dest => dest.Cliente, opt => opt.Ignore()) // idem arriba
               .ForMember(dest => dest.Comentarios, opt => opt.Ignore()); // si manejás comentarios aparte

            #region Diccionario
            //Uso Enum.Parse<EstadoObra>(src.EstadoObra) porque en los DTOs lo guardamos como string("Iniciada", "EnProceso", etc.), y en la entidad es un enum.
            //Cliente lo puse como.Ignore() porque normalmente lo resolvés con el ClienteId en el repositorio(no llega todo el objeto desde el cliente).
            //Los comentarios los mapeo a string en el GET, pero en POST/PUT podés decidir si permitir crearlos/modificarlos desde otro endpoint.
            #endregion

        // ======================= (Acá vas agregando más entidades/DTOs en el futuro) =======================
        }
    }
}