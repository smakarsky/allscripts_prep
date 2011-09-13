using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static FilteringExtensionPoint<ItemToMatch, PropertyType> has_a<PropertyType>(Func<ItemToMatch, PropertyType> property_accessor)
        {
            return new FilteringExtensionPoint<ItemToMatch, PropertyType>(property_accessor);
        }

    }
}