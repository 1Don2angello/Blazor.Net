using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Parameters
{
    public class PaginationParameters
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}