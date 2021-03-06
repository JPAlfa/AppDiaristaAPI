﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppDiarista.Data.Models
{
    [Table("Diarista", Schema = "dbo")]
    public partial class Diarista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public int IdEndereco { get; set; }
        public double PrecoDiaria { get; set; }
        public double Nota { get; set; }
    }
}
