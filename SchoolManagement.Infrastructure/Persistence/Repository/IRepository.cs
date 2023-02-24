using SchoolManagement.Domain.Entities.Abstractions;
using SchoolManagement.Domain.Specifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Persistence.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity FindById(int id);
        IEnumerable<TEntity> Find( ISpecification<TEntity> specification = null, bool tracking = false);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Update(TEntity entity);    
    }
}
