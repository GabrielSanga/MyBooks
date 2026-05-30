using Microsoft.EntityFrameworkCore;
using MyBooks.Core.ReadModels;

namespace MyBooks.Infrastructure.Persistence.Extensions
{
    public static class Extensions
    {

        public static async Task<PaginationResult<T>> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PaginationResult<T>();

            result.Page = page;
            result.PageSize = pageSize;
            result.ItemsCount = await query.CountAsync();
            result.TotalPages = (int)Math.Ceiling(((double)result.ItemsCount / pageSize));
            result.Data = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return result;
        }

    }
}
