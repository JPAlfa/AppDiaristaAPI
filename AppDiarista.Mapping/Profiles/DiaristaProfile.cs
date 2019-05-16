using AppDiarista.Data.Models;
using AppDiarista.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.Mapping.Profiles
{
    public class DiaristaProfile : Profile
    {
        public DiaristaProfile()
        {
            CreateMap<DiaristaEEnderecoDTO, Diarista>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.IdDiarista))
                .ReverseMap();
            CreateMap<DiaristaDTO, Diarista>().ReverseMap();
        }
    }
}
