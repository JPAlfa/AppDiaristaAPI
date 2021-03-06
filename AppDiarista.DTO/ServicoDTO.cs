﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.DTO
{
    public class ServicoDTO
    {
        public int Id { get; set; }
        public int IdContratante { get; set; }
        public int IdDiarista { get; set; }
        public double Preco { get; set; }
        public DateTime DataServico { get; set; }
        public bool Confirmado { get; set; }
        public bool Realizado { get; set; }
        public int Nota { get; set; }
    }
}
