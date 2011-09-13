using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static ComparableCriteriaFactory<ItemToMatch, PropertyType> has_an<PropertyType>(
            Func<ItemToMatch, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>

        {
            // Predicate<ItemToMatch> condition;
            //new AnonymousMatch<ItemToMatch>(x => property_accessor(x).CompareTo(value) > 0);
            //new AnonymousMatch<ItemToMatch>(x =>(property_accessor(x).CompareTo(begin_value) >= 0 &&property_accessor(x).CompareTo(end_value) <= 0));
            //AnonymousMatch<ItemToMatch> am = new AnonymousMatch<ItemToMatch>(condition);
            return new ComparableCriteriaFactory<ItemToMatch, PropertyType>(property_accessor,has_a(property_accessor));
        }

        public static CriteriaFactory<ItemToMatch, PropertyType> has_a<PropertyType>(Func<ItemToMatch, PropertyType> property_accessor)
        {
            // new AnonymousMatch<ItemToMatch>(x => new List<PropertyType>(possible_values).Contains(property_accessor(x)));

            return new CriteriaFactory<ItemToMatch, PropertyType>(property_accessor);
        }
    }
}