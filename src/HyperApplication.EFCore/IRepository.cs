using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperApplication.EFCore
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The find method.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>
        /// The <see cref="TEntity" />.
        /// </returns>
        //TEntity Find(params object[] keyValues);

        /// <summary>
        /// The select query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// The <see cref="IQueryable" />.
        /// </returns>
        //IQueryable<TEntity> SelectQuery(string query, params object[] parameters);

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// The insert range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// The insert or update graph.
        /// </summary>
        /// <param name="entity">The entity.</param>
        //void InsertOrUpdateGraph(TEntity entity);

        /// <summary>
        /// The insert graph range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        //void InsertGraphRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void UpdateRange(IEnumerable<TEntity> entity);

        /// <summary>
        /// The delete method.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        //void Delete(object id);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">The entity.</param>
        //void Delete(TEntity entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities">The entities.</param>
        //void DeleteRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// The queryable.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable" />.
        /// </returns>
        IQueryable<TEntity> Queryable();

        /// <summary>
        /// The get repository.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>
        /// The <see cref="IRepository" />.
        /// </returns>
        //IRepository<T> GetRepository<T>() where T : class;
    }
}
