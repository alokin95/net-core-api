using Application.DataTransfer.Search;
using Application.Response;
using DataAccess;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Extensions
{
    public static class Extensions
    {
        public static List<T> FormatForPagedResponse<T>(this IQueryable<T> query, PagedSearch search)
        {
            return query.Skip(search.PerPage * (search.Page - 1)).Take(search.PerPage).ToList();
        }

        public static PagedResponse<T> GeneratePagedResponse<T>(this List<T> items, PagedSearch search, IQueryable<EntityBase> query) where T : class
        {
            var skipCount = search.PerPage * (search.Page - 1);

            return new PagedResponse<T>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                Total = query.Count(),
                Items = items
            };
        }

        public static void Delete(this EntityBase entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.isActive = false;
        }
    }
}
