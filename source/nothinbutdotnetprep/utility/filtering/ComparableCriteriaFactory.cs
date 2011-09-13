using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToMatch, PropertyType> property_accessor;
        private CriteriaFactory<ItemToMatch, PropertyType> criteria_factory;

        public ComparableCriteriaFactory(Func<ItemToMatch, PropertyType> property_accessor)
        {
            criteria_factory = new CriteriaFactory<ItemToMatch, PropertyType>(property_accessor);
            this.property_accessor = property_accessor;
        }

        public IMatchAn<ItemToMatch> greater_than(PropertyType value)
        {
            
            return new AnonymousMatch<ItemToMatch>(x => property_accessor(x).CompareTo(value) > 0);
        }

        public IMatchAn<ItemToMatch> between(PropertyType begin_value, PropertyType end_value)
        {
            return new AnonymousMatch<ItemToMatch>(x => (property_accessor(x).CompareTo(begin_value) >= 0 && property_accessor(x).CompareTo(end_value) <= 0));
        }

        public IMatchAn<ItemToMatch> less_than(PropertyType value)
        {
            return new AnonymousMatch<ItemToMatch>(x => property_accessor(x).CompareTo(value) < 0);
        }


        public IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal)
        {
            return criteria_factory.equal_to(value_to_equal);
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] possible_values)
        {
            return criteria_factory.equal_to_any(possible_values);
        }

        public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
        {
            return criteria_factory.not_equal_to(value);
        }

    }
}