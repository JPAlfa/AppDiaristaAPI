using AppDiarista.Data.Interfaces;
using AppDiarista.Data.Models;
using AppDiarista.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.Data
{
    public class ServicoData : RepositorioBase<Servico, int>, IServicoData
    {
        #region Propriedades

        private readonly IUOWAppDiarista uowAppDiarista;

        #endregion

        #region Construtores

        public ServicoData(IUOWAppDiarista uowAppDiarista) : base(uowAppDiarista.Servico)
        {
            this.uowAppDiarista = uowAppDiarista;
        }

        #endregion
    }
}
