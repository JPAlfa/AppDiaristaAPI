using AutoMapper;
using AppDiarista.Data.Models;
using AppDiarista.DTO;

namespace AppDiarista.Mapping.Profiles
{
    public class IntencaoProfile : Profile
    {
        public IntencaoProfile()
        {
            CreateMap<IntencaoDTO, Intent>().ReverseMap();
        }
    }
}
