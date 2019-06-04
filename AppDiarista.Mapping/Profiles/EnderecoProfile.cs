using AppDiarista.Data.Models;
using AppDiarista.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.Mapping.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<ContratanteEEnderecoDTO, Endereco>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.IdEndereco))
                .ReverseMap();
            CreateMap<DiaristaEEnderecoDTO, Endereco>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.IdEndereco))
                .ReverseMap();
            CreateMap<CadastroDTO, Endereco>().ReverseMap();
            CreateMap<EnderecoDTO, Endereco>().ReverseMap();
        }
    }
}
