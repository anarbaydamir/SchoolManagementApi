using SchoolManagement.Domain.Entities.Abstractions;
using SchoolManagement.Domain.Specifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> specification = null, bool tracking = false)
        {
            return ApplySpecification(specification, tracking);
        }

        public TEntity FindById(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification, bool tracking)
        {
            if(!tracking)
                return SpecificationEvaluator<TEntity>.GetQuery(dbContext.Set<TEntity>().AsNoTracking().AsQueryable(), specification);
            else
                return SpecificationEvaluator<TEntity>.GetQuery(dbContext.Set<TEntity>().AsQueryable(), specification);
        }
    }
}
