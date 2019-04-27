using AppDiarista.Data.Interfaces;
using AppDiarista.Data.Models;
using AppDiarista.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.Data
{
    public class DiaristaData : RepositorioBase<Diarista, int>, IDiaristaData
    {
        #region Propriedades

        private readonly IUOWAppDiarista uowAppDiarista;

        #endregion

        #region Construtores

        public DiaristaData(IUOWAppDiarista uowAppDiarista) : base(uowAppDiarista.Diarista)
        {
            this.uowAppDiarista = uowAppDiarista;
        }

        #endregion
    }
}
