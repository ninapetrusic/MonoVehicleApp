using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class QueryParamsFunctions
    {
        public static bool HasPrev(this QueryParams queryParams)
        {
            return (queryParams.Page > 1);
        }
        public static bool HasNext(this QueryParams queryParams, int total)
        {
            return (queryParams.Page < GetTotalPages(queryParams, total));
        }
        public static int GetTotalPages(this QueryParams queryParams, int total)
        {
            return (int)Math.Ceiling(total / (double)queryParams.PageSize);
        }
        public static bool IsDesc(this QueryParams queryParams)
        {
            if(!String.IsNullOrEmpty(queryParams.OrderBy))
            {
                return queryParams.OrderBy.Split(' ').Last().ToLowerInvariant().StartsWith("desc");
            }
            return false;
        }
    }
}
