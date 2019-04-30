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
            CreateMap<CadastroContratanteDTO, Endereco>().ReverseMap();
        }
    }
}
