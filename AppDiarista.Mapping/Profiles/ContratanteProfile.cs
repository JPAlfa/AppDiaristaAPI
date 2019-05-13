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
            CreateMap<CadastroContratanteDTO, Contratante>().ReverseMap();
            CreateMap<ContratanteDTO, Contratante>().ReverseMap();
        }
    }
}
