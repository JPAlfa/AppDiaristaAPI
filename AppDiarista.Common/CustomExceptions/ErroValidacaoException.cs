using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AppDiarista.Common.CustomExceptions
{
    public class ErroValidacaoException : Exception
    {
        public ICollection<ValidationResult> Erros { get; set; }

        public ErroValidacaoException(string mensagem, ICollection<ValidationResult> erros) : base(mensagem)
        {
            Erros = erros;
        }
    }
}
