using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Interfaces
{
    public interface IFilterService<T> where T:class
    {
        List<T> FilterByCategory(int? id);
        List<T> FilterByTags(int? id);
        List<T> FilterByPrice(int? price);
        List<T> FilterByName(string name);
    }
}
