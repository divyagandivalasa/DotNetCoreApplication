// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Service.cs" company="EPAM Systems India">
//   Copyright 2015
// </copyright>
// <summary>
//   The service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HyperApplication.EFCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The service.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        #region Private Fields

        /// <summary>
        /// The _repository.
        /// </summary>
        private readonly IRepository<TEntity> _repository;
        #endregion Private Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public Service(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        #endregion Constructor

        /// <summary>
        /// The find method.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>
        /// The <see cref="TEntity" />.
        /// </returns>
        //public virtual TEntity Find(params object[] keyValues)
        //{
        //    return this._repository.Find(keyValues);
        //}

        /// <summary>
        /// The select query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// The <see cref="IQueryable" />.
        /// </returns>
        //public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        //{
        //    return this._repository.SelectQuery(query, parameters).AsQueryable();
        //}

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(TEntity entity)
        {
            this._repository.Insert(entity);
        }

        /// <summary>
        /// The insert range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            this._repository.InsertRange(entities);
        }

        /// <summary>
        /// The insert or update graph.
        /// </summary>
        /// <param name="entity">The entity.</param>
        //public virtual void InsertOrUpdateGraph(TEntity entity)
        //{
        //    this._repository.InsertOrUpdateGraph(entity);
        //}

        /// <summary>
        /// The insert graph range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        //public virtual void InsertGraphRange(IEnumerable<TEntity> entities)
        //{
        //    this._repository.InsertGraphRange(entities);
        //}

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            this._repository.Update(entity);
        }

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            this._repository.UpdateRange(entities);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities">The entities.</param>
        //public virtual void DeleteRange(IEnumerable<TEntity> entities)
        //{
        //    this._repository.DeleteRange(entities);
        //}

        /// <summary>
        /// The delete method.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        //public virtual void Delete(object id)
        //{
        //    this._repository.Delete(id);
        //}

        /// <summary>
        /// The delete method.
        /// </summary>
        /// <param name="entity">The entity.</param>
        //public virtual void Delete(TEntity entity)
        //{
        //    this._repository.Delete(entity);
        //}

        /// <summary>
        /// The find async.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        //public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        //{
        //    return await this._repository.FindAsync(keyValues);
        //}

        /// <summary>
        /// The find async.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="keyValues">The key values.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        //public virtual async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        //{
        //    return await this._repository.FindAsync(cancellationToken, keyValues);
        //}

        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        //public virtual async Task<bool> DeleteAsync(params object[] keyValues)
        //{
        //    return await this.DeleteAsync(CancellationToken.None, keyValues);
        //}

        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="keyValues">The key values.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        //public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        //{
        //    return await this._repository.DeleteAsync(cancellationToken, keyValues);
        //}

        /// <summary>
        /// The queryable.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable" />.
        /// </returns>
        public IQueryable<TEntity> Queryable()
        {
            return this._repository.Queryable();
        }
    }
}