using System;

namespace OnlineShop.Common.Helper
{
    public class BasePaginationViewModel
    {
        public long CurrentPage { get; set; } = 1;

        public long TotalPageCount { get; set; } = 1;

        public long StartPage { get; set; }

        public long EndPage { get; set; }

        public static BasePaginationViewModel InitiatePagerViewModel(long totalPageCount=1, int currentPagenumber=1, int itemPerPage = 10)
        {
            int totalPages = (int)Math.Ceiling(totalPageCount / (decimal)itemPerPage);
            int currentPage = currentPagenumber;
            long startPage = currentPage - 2;
            long endPage = currentPage + 1;

            if (startPage <= 0)
            {
                endPage -= startPage - 1;
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                
                if (endPage > 4)
                    startPage = endPage - 3;
                
            }

            return new BasePaginationViewModel
            {
                CurrentPage = currentPage,
                TotalPageCount = totalPages,
                StartPage = startPage,
                EndPage = endPage
            };
        }
    }
}
