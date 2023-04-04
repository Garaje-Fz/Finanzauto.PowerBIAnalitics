using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Infraestructure.Specification
{
    public class SpecificationEvaluator<T> where T : Entity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            if (spec.Criteria != null)
                inputQuery = inputQuery.Where(spec.Criteria);

            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));
            inputQuery = spec.IncludeStrings.Aggregate(inputQuery, (current, include) => current.Include(include));

            if (spec.OrderBy != null)
                inputQuery = inputQuery.OrderBy(spec.OrderBy);

            if (spec.OrderByDescending != null)
                inputQuery = inputQuery.OrderByDescending(spec.OrderByDescending);

            if (spec.IsPagingEnabled)
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);

            return inputQuery;
        }
    }
}
