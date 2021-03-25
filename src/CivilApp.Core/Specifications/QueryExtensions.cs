using Ardalis.Specification;

using CivilApp.Core.Specifications.Filters;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Core.Specifications
{
    public static class QueryExtensions
    {
        public static IOrderedSpecificationBuilder<T> OrderBy<T>(
            this ISpecificationBuilder<T> specificationBuilder,
            [NotNull] List<SortField> sortFields)
        {
            if (sortFields.Count != 0)
            {
                foreach (var field in sortFields)
                {
                    var matchedProperty = typeof(T).GetProperties().FirstOrDefault(p => p.Name.ToLower() == field.FieldName.ToLower());
                    if (matchedProperty == null)
                        throw new ArgumentNullException(field.FieldName);

                    var paramExpr = Expression.Parameter(typeof(T));
                    var propAccess = Expression.PropertyOrField(paramExpr, matchedProperty.Name);
                    var expr = Expression.Lambda<Func<T, object?>>(propAccess, paramExpr);
                    ((List<(Expression<Func<T, object?>> OrderExpression, OrderTypeEnum OrderType)>)specificationBuilder.Specification.OrderExpressions)
                        .Add((expr, field.SortType));
                }
            }
            var orderedSpecificationBuilder = new OrderedSpecificationBuilder<T>(specificationBuilder.Specification);

            return orderedSpecificationBuilder;
        }
    }
}
