using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiaristaDTO
{
    public class Diarista
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public double PrecoDiaria { get; set; }
        public float Nota { get; set; }
    }
}
