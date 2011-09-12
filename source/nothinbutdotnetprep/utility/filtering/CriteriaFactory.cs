using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType>
    {
        Func<ItemToMatch, PropertyType> property_accessor;

        public CriteriaFactory(Func<ItemToMatch, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] possible_values)
        {
            return new AnonymousMatch<ItemToMatch>(x => new List<PropertyType>(possible_values).Contains(property_accessor(x)));
        }
    }
}