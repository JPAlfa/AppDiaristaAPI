using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.DTO
{
    public class DiaristaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public double PrecoDiaria { get; set; }
        public int Nota { get; set; }
    }
}
