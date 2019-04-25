using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppDiarista.Data.Interfaces
{
    /// <summary>
    /// Repositório base
    /// </summary>
    /// <typeparam name="TEntidade">Tabela da Unidade de trabalho</typeparam>
    /// <typeparam name="TTipoID">Tipo do ID da tabela</typeparam>
    public interface IRepositorioBase<TEntidade, TTipoID> where TEntidade : class
    {
        IQueryable<TEntidade> ListarTodos();
        IQueryable<TEntidade> ListarTodos(params Expression<Func<TEntidade, object>>[] include);
        //IQueryable<TEntidade> ListarTodos(params Expression<Func<TEntidade, IEnumerable<object>>>[] queryIncludeFilter);
        Task<TEntidade> RetornarPorID(TTipoID id);
        Task<TEntidade> RetornarPorID(Expression<Func<TEntidade, bool>> predicate);
        Task<TEntidade> RetornarPorID(Expression<Func<TEntidade, bool>> predicate, params Expression<Func<TEntidade, object>>[] include);
        //Task<TEntidade> RetornarPorID(Expression<Func<TEntidade, bool>> predicate, params Expression<Func<TEntidade, IEnumerable<object>>>[] queryIncludeFilter);
        IQueryable<TEntidade> Listar(Expression<Func<TEntidade, int, bool>> predicate);
        IQueryable<TEntidade> Listar(Expression<Func<TEntidade, int, bool>> predicate, params Expression<Func<TEntidade, object>>[] include);
        //IQueryable<TEntidade> Listar(Expression<Func<TEntidade, int, bool>> predicate, params Expression<Func<TEntidade, IEnumerable<object>>>[] queryIncludeFilter);
        IQueryable<TEntidade> Listar(Expression<Func<TEntidade, bool>> predicate);
        IQueryable<TEntidade> Listar(Expression<Func<TEntidade, bool>> predicate, params Expression<Func<TEntidade, object>>[] include);
        //IQueryable<TEntidade> Listar(Expression<Func<TEntidade, bool>> predicate, params Expression<Func<TEntidade, IEnumerable<object>>>[] queryIncludeFilter);
    }
}
