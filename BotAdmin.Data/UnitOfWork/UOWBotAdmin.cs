using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using AppDiarista.Data.UnitOfWork.Interfaces;
using AppDiarista.Data.Models;

namespace AppDiarista.Data.UnitOfWork
{
    public class UOWAppDiarista : ExternoContext, IUOWAppDiarista
    {
        #region Propriedades
        #endregion

        #region Construtores
        public UOWAppDiarista(DbContextOptions<ExternoContext> options) : base(options)
        {

        }
        #endregion

        #region Métodos Comuns
        DbLoggerCategory.Database IUOWAppDiarista.Database => throw new NotImplementedException();

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await base.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                //this.SalvarLogsBanco(ex);
                throw;
            }
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (System.Exception ex)
            {
                //this.SalvarLogsBanco(ex);
                throw;
            }
        }
        #endregion
    }
}
