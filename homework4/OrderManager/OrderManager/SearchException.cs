using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    class SearchException:ApplicationException
    {
        public SearchException(string message) : base(message) { }
    }
}
