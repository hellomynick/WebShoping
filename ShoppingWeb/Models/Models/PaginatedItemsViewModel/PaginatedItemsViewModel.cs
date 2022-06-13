using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.PaginatedItemsViewModel
{
    public class PaginatedItemsViewModel<TEntity> where TEntity : class
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long Count { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
        public PaginatedItemsViewModel(int pageSize, int pageIndex, long count, IEnumerable<TEntity> data)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Count = count;
            Data = data;
        }
    }
}
