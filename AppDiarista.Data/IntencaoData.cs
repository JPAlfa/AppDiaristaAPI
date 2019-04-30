using AppDiarista.Data.Interfaces;
using AppDiarista.Data.Models;
using AppDiarista.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.Data
{
    public class IntencaoData : RepositorioBase<Intent, int>, IIntencaoData
    {
        #region Propriedades

        private readonly IUOWAppDiarista uowAppDiarista;

        #endregion

        #region Construtores

        public IntencaoData(IUOWAppDiarista uowAppDiarista) : base(uowAppDiarista.Intent)
        {
            this.uowAppDiarista = uowAppDiarista;
        }

        #endregion
    }
}
