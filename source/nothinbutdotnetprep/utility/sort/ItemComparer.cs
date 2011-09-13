using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.utility.sort
{
    public interface IItemComparer
    {
    }

    public class ItemComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>, IItemComparer where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToCompare, PropertyType> property_accessor;

        public ItemComparer(Func<ItemToCompare, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }
 

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return property_accessor(x).CompareTo(property_accessor(y));
        }
    }

    public class NegatingComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>, IItemComparer where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToCompare, PropertyType> property_accessor;

        public NegatingComparer(Func<ItemToCompare, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }


        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return property_accessor(y).CompareTo(property_accessor(x));
        }
    }
}
