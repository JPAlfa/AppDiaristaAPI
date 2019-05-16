using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.DTO
{
    public class ContratanteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public int IdEndereco { get; set; }
    }
}
