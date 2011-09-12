using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static ComparableCriteriaFactory<ItemToMatch, PropertyType> has_an<PropertyType>(
            Func<ItemToMatch, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>

        {
            return new ComparableCriteriaFactory<ItemToMatch, PropertyType>(property_accessor);
        }

        public static CriteriaFactory<ItemToMatch, PropertyType> has_a<PropertyType>(
            Func<ItemToMatch, PropertyType> property_accessor)
        {
            return new CriteriaFactory<ItemToMatch, PropertyType>(property_accessor);
        }
    }

    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToMatch, PropertyType> property_accessor;

        public ComparableCriteriaFactory(Func<ItemToMatch, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public IMatchAn<ItemToMatch> greater_than(PropertyType value)
        {
            return new AnonymousMatch<ItemToMatch>(x => property_accessor(x).CompareTo(value) > 0);
        }
    }
}