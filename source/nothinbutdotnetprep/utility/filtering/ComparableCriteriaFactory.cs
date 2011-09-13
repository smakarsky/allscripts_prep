using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        ICreateSpecifications<ItemToMatch, PropertyType> original_factory;

        public ComparableCriteriaFactory(ICreateSpecifications<ItemToMatch, PropertyType> original_factory)
        {
            this.original_factory = original_factory;
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal)
        {
            return original_factory.equal_to(value_to_equal);
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] possible_values)
        {
            return original_factory.equal_to_any(possible_values);
        }

        public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
        {
            return original_factory.not_equal_to(value);
        }


        public IMatchAn<ItemToMatch> create_from(IMatchAn<PropertyType> real_matcher)
        {
            return original_factory.create_from(real_matcher);
        }

        public IMatchAn<ItemToMatch> greater_than(PropertyType value)
        {
            return create_from(new FallsInRange<PropertyType>(
                new RangeWithNoUpperBound<PropertyType>(value)));
        }

        public IMatchAn<ItemToMatch> between(PropertyType begin_value, PropertyType end_value)
        {
            return create_from(new FallsInRange<PropertyType>(
                new InclusiveRange<PropertyType>(begin_value, end_value)));
        }
    }
}