using AppDiarista.Data.Interfaces;
using AppDiarista.Data.Models;
using AppDiarista.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.Data
{
    public class ContratanteData : RepositorioBase<Contratante, int>, IContratanteData
    {
        #region Propriedades

        private readonly IUOWAppDiarista uowAppDiarista;

        #endregion

        #region Construtores

        public ContratanteData(IUOWAppDiarista uowAppDiarista) : base(uowAppDiarista.Contratante)
        {
            this.uowAppDiarista = uowAppDiarista;
        }

        #endregion
    }
}
