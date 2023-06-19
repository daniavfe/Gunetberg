using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunetberg.Repository.Types
{
    public class Pagination
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
