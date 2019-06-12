using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.DTO
{
    public class AgendamentoServicoDTO
    {
        public int IdContratante { get; set; }
        public int IdDiarista { get; set; }
        public DateTime DataServico { get; set; }
    }
}
