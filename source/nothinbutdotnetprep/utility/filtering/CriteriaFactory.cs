using System;

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
            return new AnonymousMatch<ItemToMatch>(x => property_accessor(x).Equals(value_to_equal));
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            throw new NotImplementedException();
        }
    }
}