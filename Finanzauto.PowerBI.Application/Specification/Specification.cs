﻿using Finanzauto.PowerBI.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Application.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification()
        {
        }
        public Specification(Expression<Func<T, bool>> criteria) => Criteria = criteria;

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression) => OrderByDescending = orderByDescendingExpression;

        public int Take { get; private set; }
        public int Skip { get; private set; }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression) => Includes.Add(includeExpression);
        protected void AddInclude(string includeString) => IncludeStrings.Add(includeString);
    }
}
