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
            CreateMap<CadastroDiaristaDTO, Diarista>().ReverseMap();
            CreateMap<DiaristaDTO, Diarista>().ReverseMap();
        }
    }
}
