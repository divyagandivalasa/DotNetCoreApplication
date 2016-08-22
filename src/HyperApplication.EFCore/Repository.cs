using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HyperApplication.EFCore
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> databaseSet;

        private HashSet<object> entitiesChecked;

        public IDataContext<TEntity> DbContext { get; private set; }
        public Repository(IDataContext<TEntity> context)
        {
            this.DbContext = context;
            var databaseContext = context as DbContext;
            if (databaseContext != null)
            {
                databaseSet = databaseContext.Set<TEntity>();
            }
        }
        //public virtual TEntity Find(params object[] keyValues)
        //{
        //    return this.databaseSet.Find(keyValues);
        //}
        /// <summary>
        /// The select query.
        /// </summary>
        /// <param name="query">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// The <see cref="IQueryable" />.
        /// </returns>
        //public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        //{
        //    return this.databaseSet.SqlQuery(query, parameters).AsQueryable();
        //}

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(TEntity entity)
        {
            this.databaseSet.Attach(entity);
            this.DbContext.SaveChanges();
        }
        /// <summary>
        /// The insert range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.databaseSet.Add(entity);
            }
            this.DbContext.SaveChanges();
        }
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            this.databaseSet.Attach(entity);
            this.DbContext.SaveChanges();
        }
        /// <summary>
        /// The update range.
        /// </summary>
        /// <param name="entity">The entities.</param>
        public virtual void UpdateRange(IEnumerable<TEntity> entity)
        {
            foreach (var en in entity)
            {
                this.databaseSet.Attach(en);
            }
            this.DbContext.SaveChanges();
        }
        /// <summary>
        /// The insert graph range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void InsertGraphRange(IEnumerable<TEntity> entities)
        {
            this.databaseSet.AddRange(entities);
        }
        /// <summary>
        /// The delete method.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        //public virtual void Delete(object id)
        //{
        //    var entity = this.databaseSet.Find(id);
        //    if (entity != null)
        //    {
        //        this.Delete(entity);
        //    }
        //}
        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">The entity.</param>
        //public virtual void Delete(TEntity entity)
        //{
        //    entity.ObjectState = ObjectState.Deleted;
        //    this.databaseSet.Remove(entity);
        //    this.DbContext.SaveChanges();
        //}
        /// <summary>
        /// The delete range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        //public virtual void DeleteRange(IEnumerable<TEntity> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        entity.ObjectState = ObjectState.Deleted;
        //        this.databaseSet.Attach(entity);
        //    }
        //    this.DbContext.SaveChanges();
        //}

        /// <summary>
        /// The queryable.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable" />.
        /// </returns>
        public IQueryable<TEntity> Queryable()
        {
            return this.databaseSet;
        }
        /// <summary>
        /// The find async.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        //public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        //{
        //    return await databaseSet.FindAsync(keyValues);
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
        //    return await databaseSet.FindAsync(cancellationToken, keyValues);
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
        //    return await DeleteAsync(CancellationToken.None, keyValues);
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
        //    var entity = await FindAsync(cancellationToken, keyValues);
        //    if (entity == null)
        //    {
        //        return false;
        //    }
        //    entity.ObjectState = ObjectState.Deleted;
        //    databaseSet.Attach(entity);
        //    return true;
        //}
        /// <summary>
        /// Selects the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="page">The page numbers.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>The <see cref="IQueryable" />.</returns>
        internal IQueryable<TEntity> Select(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = databaseSet;
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (filter != null)
            {
                //query = query.AsExpandable().Where(filter);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query;
        }
        /// <summary>
        /// Selects the asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="page">The page size.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>The Task of IEnumerable.</returns>
        internal async Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            return await Select(filter, orderBy, includes, page, pageSize).ToListAsync();
        }

        /// <summary>
        /// The insert or update graph.
        /// </summary>
        /// <param name="entity">The entity.</param>
        //public virtual void InsertOrUpdateGraph(TEntity entity)
        //{
        //    SyncObjectGraph(entity);
        //    entitiesChecked = null;
        //    databaseSet.Attach(entity);
        //}
        /// <summary>
        /// Synchronizes the object graph.
        /// </summary>
        /// <param name="entity">The entity.</param>
        //private void SyncObjectGraph(object entity) // scan object graph for all 
        //{
        //    if (entitiesChecked == null)
        //    {
        //        entitiesChecked = new HashSet<object>();
        //    }
        //    if (entitiesChecked.Contains(entity))
        //    {
        //        return;
        //    }
        //    entitiesChecked.Add(entity);
        //    var objectState = entity as IObjectState;
        //    if (objectState != null && objectState.ObjectState == ObjectState.Added)
        //    {
        //        this.DbContext.SyncObjectState(objectState);
        //    }
        //    // Set tracking state for child collections
        //    foreach (var prop in entity.GetType().GetProperties())
        //    {
        //        // Apply changes to 1-1 and M-1 properties
        //        var trackableRef = prop.GetValue(entity, null) as IObjectState;
        //        if (trackableRef != null)
        //        {
        //            if (trackableRef.ObjectState == ObjectState.Added)
        //            {
        //                this.DbContext.SyncObjectState(objectState);
        //            }
        //            SyncObjectGraph(prop.GetValue(entity, null));
        //        }
        //        // Apply changes to 1-M properties
        //        var items = prop.GetValue(entity, null) as IEnumerable<IObjectState>;
        //        if (items == null)
        //        {
        //            continue;
        //        }
        //        Debug.WriteLine("Checking collection: " + prop.Name);
        //        foreach (var item in items)
        //        {
        //            SyncObjectGraph(item);
        //        }
        //    }
    }
}
