using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiaristaDTO
{
    public class Servico
    {
        public Contratante Contratante { get; set; }
        public Diarista Diarista { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }
        public short Nota { get; set; }
        public bool Realizado { get; set; }
    }
}
