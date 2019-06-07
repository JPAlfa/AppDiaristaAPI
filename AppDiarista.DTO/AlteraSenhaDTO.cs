using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.DTO
{
    public class AlteraSenhaDTO
    {
        public int IdDiarista { get; set; }
        public int IdContratante { get; set; }
        public string Senha { get; set; }
    }
}
