using System;
using System.Threading.Tasks;

namespace AppDiarista.Business.Interfaces
{
    public interface IIntencaoBusiness
    {
        Task<bool> VerificaPermiteInserirBanco(Data.Models.Intent novoItem);
        bool VerificaPermiteAlterarBanco(int id, Data.Models.Intent itemAlterar);
    }
}
