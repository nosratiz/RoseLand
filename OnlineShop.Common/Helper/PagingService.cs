﻿using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Common.Helper
{
    public class PagingService<TEntity> where TEntity : class

    {

        public async Task<PagedList<TEntity>> GetPagedAsync(int pageNumber, int pageSize, IQueryable<TEntity> query)
        {
            if (pageSize <= 0)
                pageSize = 10;

            var rowsCount = query.Count();

            if (rowsCount <= pageSize || pageNumber <= 1)
                pageNumber = 1;

            return await PagedList<TEntity>.CreateAsync(query, pageNumber, pageSize, rowsCount);
        }

        
    }
}