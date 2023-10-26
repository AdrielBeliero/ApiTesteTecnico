using AutoMapper;

namespace ApiTesteTecnico.Map
{
    public class BoletoMapper : Profile
    {
        public BoletoMapper()
        {
            CreateMap<Boleto, BoletoDTO>();
            CreateMap<BoletoDTO, Boleto>();
        }
    }
}
