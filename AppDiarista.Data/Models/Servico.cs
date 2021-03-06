﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppDiarista.Data.Models
{
    [Table("Servico", Schema = "dbo")]
    public partial class Servico
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
