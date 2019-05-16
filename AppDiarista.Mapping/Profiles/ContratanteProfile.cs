using AppDiarista.Data.Models;
using AppDiarista.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.Mapping.Profiles
{
    public class ContratanteProfile : Profile
    {
        public ContratanteProfile()
        {
            CreateMap<ContratanteEEnderecoDTO, Contratante>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.IdContratante))
                .ReverseMap();
            CreateMap<ContratanteDTO, Contratante>().ReverseMap();
        }
    }
}
