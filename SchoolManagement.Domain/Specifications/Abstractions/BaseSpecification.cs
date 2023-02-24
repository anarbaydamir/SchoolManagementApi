using SchoolManagement.Domain.Specifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Specifications.Abstractions
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification() { }

        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; } 

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression) 
        {  
            Includes.Add(includeExpression);
        }
        
        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression) 
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression) 
        { 
            OrderBy = orderByExpression;
        }
    }
}
