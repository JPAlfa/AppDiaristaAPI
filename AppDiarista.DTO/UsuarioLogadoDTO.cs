using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.DTO
{
    public class UsuarioLogadoDTO
    {
        public string Token { get; set; }
        public DiaristaDTO Diarista { get; set; }
        public ContratanteDTO Contratante { get; set; }
    }
}
