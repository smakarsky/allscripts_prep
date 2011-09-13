using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
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
            return CreateAnonymousMatch(x => new List<PropertyType>(possible_values).Contains(property_accessor(x)));
               // new AnonymousMatch<ItemToMatch>(x => new List<PropertyType>(possible_values).Contains(property_accessor(x)));
        }

        public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }

        public IMatchAn<ItemToMatch> CreateAnonymousMatch(Predicate<ItemToMatch> property_accessor_value)
        {
            return new AnonymousMatch<ItemToMatch>(property_accessor_value);
        }
    }
}