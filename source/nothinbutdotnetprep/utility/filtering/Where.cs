using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static CriteriaFactory has_a<PropertyType>(Func<ItemToMatch, PropertyType> property_accessor)
        {
            throw new NotImplementedException();
        }
    }

    public class CriteriaFactory
    {
    }
}