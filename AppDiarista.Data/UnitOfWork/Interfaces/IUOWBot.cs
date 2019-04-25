using AppDiarista.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AppDiarista.Data.UnitOfWork.Interfaces
{
    public interface IUOWAppDiarista : IDisposable
    {
        #region Entidades do banco
        
        DbSet<Intent> Intent { get; set; }

        #endregion

        #region Procedures

        #endregion

        #region Métodos comuns

        Database Database { get; }

        //DbContextConfiguration Configuration { get; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Confirma as alterações feitas em todos os repositórios desta unidade.
        /// Override para concentrar regras de auditoria
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Confirma as alterações feitas em todos os repositórios desta unidade.
        /// Override para concentrar regras de auditoria
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        #endregion
    }
}
