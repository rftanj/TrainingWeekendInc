using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTrainingWEEKEND.Helper.Pagination
{
    public class Paging
    {
        const int maxPageSize = 50;

        private int _pageSize = 5;
        public int pageNumber { get; set; } = 2;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
