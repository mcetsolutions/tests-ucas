using System.Linq;
using System.Linq.Expressions;

namespace Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Extensions
{
    internal static class IQueryableExtensions
    {
        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> queryable, string propertyName, bool ascending = true)
        {
            var elementType = typeof(T);
            var orderByMethodName = ascending ? "OrderBy" : "OrderByDescending";

            var parameterExpression = Expression.Parameter(elementType);
            var bodyExpression = Expression.PropertyOrField(parameterExpression, propertyName);
            var selector = Expression.Lambda(bodyExpression, parameterExpression);

            var orderByExpression = Expression.Call(typeof(Queryable), orderByMethodName,
                new[] { elementType, bodyExpression.Type }, 
                queryable.Expression, selector);

            return queryable.Provider.CreateQuery<T>(orderByExpression);
        }
    }
}
