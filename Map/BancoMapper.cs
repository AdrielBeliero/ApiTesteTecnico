using AutoMapper;

namespace ApiTesteTecnico.Map
{
    public class BancoMapper : Profile
    {
        public BancoMapper() 
        {
            CreateMap<Banco, BancoDTO>();
            CreateMap<BancoDTO, Banco>();
        }
    }
}
