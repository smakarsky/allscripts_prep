using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static CriteriaFactory<ItemToMatch,PropertyType> has_a<PropertyType>(Func<ItemToMatch, PropertyType> property_accessor)
        {
            return new CriteriaFactory<ItemToMatch, PropertyType>(property_accessor);
        }
    }
}