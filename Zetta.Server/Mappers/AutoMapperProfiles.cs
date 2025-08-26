//using AutoMapper;
//using Zetta.BD.DATA.ENTITY;
//using Zetta.Shared.DTO.ClienteDTO;
//using Zetta.Shared.DTOS.Cliente;

//namespace Zetta.Server.Mappers
//{
//    public class AutoMapperProfiles : Profile
//    {
//        public AutoMapperProfiles()
//        {
//            // ======================= Cliente =======================

//            // GET
//            CreateMap<Cliente, GET_ClienteDTO>().ForMember(dest => dest.Nombre, opt => opt.MapFrom(src =>src.Nombre));

//            // POST
//            CreateMap<POST_ClienteDTO, Cliente>()
//                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => $"Cliente-{src.Nombre}-{src.Apellido}"));

//            // PUT
//            CreateMap<PUT_ClienteDTO, Cliente>()
//                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => $"Cliente-{src.Nombre}-{src.Apellido}"));

//            // ======================= (Acá vas agregando más entidades/DTOs en el futuro) =======================
//        }
//    }
//}
