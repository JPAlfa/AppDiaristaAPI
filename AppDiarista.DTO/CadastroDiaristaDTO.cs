using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.DTO
{
    public class CadastroDiaristaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public double PrecoDiaria { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
    }
}
