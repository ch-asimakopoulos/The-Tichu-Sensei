using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TichuSensei.Core.Application.Shared.Models
{
    /// <summary>
    /// A Paginated List, with a page index, a total page count and a total item count.
    /// </summary>
    /// <typeparam name="T">The type of items the list contains.</typeparam>
    public class PaginatedList<T>
    {
        /// <summary>
        /// The list of items the current page contains.
        /// </summary>
        public List<T> Items { get; }
        /// <summary>
        /// The current page index.
        /// </summary>
        public int PageIndex { get; }
        /// <summary>
        /// The total pages this list contains.
        /// </summary>
        public int TotalPages { get; }
        /// <summary>
        /// The total item count of this list.
        /// </summary>
        public int TotalCount { get; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        /// <summary>
        /// Determines if we are past the first page.
        /// </summary>
        public bool HasPreviousPage => PageIndex > 1;
        /// <summary>
        /// Determines if we haven't reached the last page.
        /// </summary>
        public bool HasNextPage => PageIndex < TotalPages;
        /// <summary>
        /// Creates a Paginated List asynchronsouly.
        /// </summary>
        /// <param name="source">The query which will produce the list results.</param>
        /// <param name="pageIndex">The current page index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result containts a Paginated List with elements corresponding to the provided page index and page size.</returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int count = await source.CountAsync();
            List<T> items = await source.Skip((pageIndex - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
