using System;

namespace AppDiarista.Common.CustomExceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string mensagem) : base(mensagem)
        {
        }

        public string CampoErro { get; set; }
    }
}
