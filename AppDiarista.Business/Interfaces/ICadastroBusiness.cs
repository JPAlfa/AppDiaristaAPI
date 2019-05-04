using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDiarista.Business.Interfaces
{
    public interface ICadastroBusiness
    {
        Task<bool> VerificaPermiteCadastrarDiaristaBanco(string email);
        Task<bool> VerificaPermiteCadastrarContratanteBanco(string email);
    }
}
