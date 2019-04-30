using AppDiarista.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace AppDiarista.Data
{
    public class RepositorioBase<TEntidade, TTipoID> : IRepositorioBase<TEntidade, TTipoID> where TEntidade : class
    {
        #region Propriedades

        /// <summary>
        /// Tabela vinculada ao repositório base para construção de queries automáticas
        /// </summary>
        protected DbSet<TEntidade> EntidadeBaseRepo { get; set; }

        #endregion


        #region Construtores

        public RepositorioBase(DbSet<TEntidade> entidade)
        {
            this.EntidadeBaseRepo = entidade;
        }

        #endregion


        #region Métodos públicos

        public IQueryable<TEntidade> Listar(Expression<Func<TEntidade, int, bool>> predicate)
        {
            return this.EntidadeBaseRepo.Where(predicate);
        }

        public IQueryable<TEntidade> Listar(Expression<Func<TEntidade, int, bool>> predicate, params Expression<Func<TEntidade, object>>[] include)
        {
            IQueryable<TEntidade> query = AdicionarIncludes(include);
            return query.Where(predicate);
        }

        public IQueryable<TEntidade> Listar(Expression<Func<TEntidade, bool>> predicate)
        {
            return this.EntidadeBaseRepo.Where(predicate);
        }

        public IQueryable<TEntidade> Listar(Expression<Func<TEntidade, bool>> predicate, params Expression<Func<TEntidade, object>>[] include)
        {
            IQueryable<TEntidade> query = AdicionarIncludes(include);
            return query.Where(predicate);
        }

        public IQueryable<TEntidade> ListarTodos()
        {
            return this.EntidadeBaseRepo;
        }

        public IQueryable<TEntidade> ListarTodos(params Expression<Func<TEntidade, object>>[] include)
        {
            IQueryable<TEntidade> query = AdicionarIncludes(include);
            return query;
        }

        public async Task<TEntidade> RetornarPorID(TTipoID id)
        {
            return await this.EntidadeBaseRepo.FindAsync(id);
        }

        public async Task<TEntidade> RetornarPorID(Expression<Func<TEntidade, bool>> predicate)
        {
            return await this.EntidadeBaseRepo.FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntidade> RetornarPorID(Expression<Func<TEntidade, bool>> predicate, params Expression<Func<TEntidade, object>>[] include)
        {
            IQueryable<TEntidade> query = AdicionarIncludes(include);
            return await query.FirstOrDefaultAsync(predicate);
        }

        //public IQueryable<TEntidade> ListarTodos(params Expression<Func<TEntidade, IEnumerable<object>>>[] queryIncludeFilter)
        //{
        //    IQueryable<TEntidade> query = AdicionarIncludesFilter<object>(queryIncludeFilter);
        //    return query;
        //}

        //public async Task<TEntidade> RetornarPorID(Expression<Func<TEntidade, bool>> predicate, params Expression<Func<TEntidade, IEnumerable<object>>>[] queryIncludeFilter)
        //{
        //    IQueryable<TEntidade> query = AdicionarIncludesFilter<object>(queryIncludeFilter);
        //    return await query.FirstOrDefaultAsync(predicate);
        //}

        //public IQueryable<TEntidade> Listar(Expression<Func<TEntidade, int, bool>> predicate, params Expression<Func<TEntidade, IEnumerable<object>>>[] queryIncludeFilter)
        //{
        //    IQueryable<TEntidade> query = AdicionarIncludesFilter<object>(queryIncludeFilter);
        //    return query.Where(predicate);
        //}

        //public IQueryable<TEntidade> Listar(Expression<Func<TEntidade, bool>> predicate, params Expression<Func<TEntidade, IEnumerable<object>>>[] queryIncludeFilter)
        //{
        //    IQueryable<TEntidade> query = AdicionarIncludesFilter<object>(queryIncludeFilter);
        //    return query.Where(predicate);
        //}

        #endregion


        #region Métodos privados

        private IQueryable<TEntidade> AdicionarIncludes<TProp>(Expression<Func<TEntidade, TProp>>[] include)
        {
            var query = this.EntidadeBaseRepo.AsQueryable();
            foreach (var i in include)
            {
                query = query.Include(i);
            }

            return query;
        }

        //private IQueryable<TEntidade> AdicionarIncludesFilter<TProp>(Expression<Func<TEntidade, IEnumerable<object>>>[] queryIncludeFilter)
        //{
        //    var query = this.EntidadeBaseRepo;
        //    foreach (var i in queryIncludeFilter)
        //    {
                
        //        query = query.IncludeFilter(i);
        //    }

        //    return query;
        //}

        #endregion
    }
}
