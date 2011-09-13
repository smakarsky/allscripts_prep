using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class FilteringExtensions
    {
        public static IMatchAn<ItemToMatch> equal_to<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingSpecifications<ItemToMatch, PropertyType> extension_point, PropertyType value_to_equal)
        {
            return equal_to_any(extension_point, value_to_equal);
        }

        public static IMatchAn<ItemToMatch> equal_to_any<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingSpecifications<ItemToMatch, PropertyType> extension_point,
            params PropertyType[] possible_values)
        {
            return create_from(extension_point, new EqualToAny<PropertyType>(possible_values));
        }

        public static IMatchAn<ItemToMatch> create_from<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingSpecifications<ItemToMatch, PropertyType> extension_point, IMatchAn<PropertyType> real_matcher)
        {
            return extension_point.create_matcher_from(real_matcher);
        }

        public static IMatchAn<ItemToMatch> greater_than<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingSpecifications<ItemToMatch, PropertyType> extension_point, PropertyType value)
            where PropertyType : IComparable<PropertyType>
        {
            return create_from(extension_point, new FallsInRange<PropertyType>(
                                                    new RangeWithNoUpperBound<PropertyType>(value)));
        }

        public static IMatchAn<ItemToMatch> between<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingSpecifications<ItemToMatch, PropertyType> extension_point, PropertyType begin_value,
            PropertyType end_value) where PropertyType : IComparable<PropertyType>
        {
            return create_from(extension_point, new FallsInRange<PropertyType>(
                                                                 new InclusiveRange<PropertyType>(begin_value, end_value)));
        }
    }
}