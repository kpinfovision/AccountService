using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Xome.Cascade2.AccountService.Application.CommonExtensions
{
    public static class DbContextExtensions
    {
        public static async Task<bool> IsDuplicateAsync<T>(this DbContext context, string propertyName, object value) where T : class
        {
            var dbSet = context.Set<T>();

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(value);
            var equalsExpression = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equalsExpression, parameter);

            return await dbSet.AnyAsync(lambda);
        }
    }
}
