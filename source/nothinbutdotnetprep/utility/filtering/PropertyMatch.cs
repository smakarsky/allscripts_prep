using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class PropertyMatch<ItemToMatch,PropertyType> : IMatchAn<ItemToMatch>
    {
        Func<ItemToMatch, PropertyType> accessor;
        IMatchAn<PropertyType> real_match;

        public PropertyMatch(Func<ItemToMatch, PropertyType> accessor, IMatchAn<PropertyType> real_match)
        {
            this.accessor = accessor;
            this.real_match = real_match;
        }

        public bool matches(ItemToMatch item)
        {
            return real_match.matches(accessor(item));

        }
    }
}