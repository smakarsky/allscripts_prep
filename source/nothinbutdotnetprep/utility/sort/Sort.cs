using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.utility.sort
{
    public class Sort<ItemToSort>
    {
        public static IComparer<ItemToSort> by_ascending<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ItemComparer<ItemToSort, PropertyType>(accessor);
       }
        public static IComparer<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new NegatingComparer<ItemToSort, PropertyType>(accessor);
        }
    }
}
