using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.DTO
{
    public class UsuarioLogadoDTO
    {
        public string Token { get; set; }
        public DiaristaEEnderecoDTO Diarista { get; set; }
        public ContratanteEEnderecoDTO Contratante { get; set; }
    }
}
