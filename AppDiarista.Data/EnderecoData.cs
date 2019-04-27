using AppDiarista.Data.Interfaces;
using AppDiarista.Data.Models;
using AppDiarista.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.Data
{
    public class EnderecoData : RepositorioBase<Endereco, int>, IEnderecoData
    {
        #region Propriedades

        private readonly IUOWAppDiarista uowAppDiarista;

        #endregion

        #region Construtores

        public EnderecoData(IUOWAppDiarista uowAppDiarista) : base(uowAppDiarista.Endereco)
        {
            this.uowAppDiarista = uowAppDiarista;
        }

        #endregion
    }
}
