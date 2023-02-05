using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ViewModel
{
    public class ProductFilterItems
    {
        public int? page { get; set; }
        public int? CatID { get; set; }
        public int? SortID { get; set; }
        public int? PriceID { get; set; }
        public int? TagID { get; set; }
        public string searchName { get; set; }
    }
}
