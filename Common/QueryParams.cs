using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class QueryParams
    {
        private const int _maxPageSize = 20;
        public int Page { get; set; } = 1;
        private int _pageSize = _maxPageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > _maxPageSize) ? _maxPageSize : value; }
        }
        public string? OrderBy { get; set; } = "Id";
        public string FilterName { get; set; } = "";
    }
}
