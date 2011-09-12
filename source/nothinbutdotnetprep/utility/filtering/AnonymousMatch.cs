using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class AnonymousMatch<ItemToMatch> : IMatchAn<ItemToMatch>
    {
        Predicate<ItemToMatch> condition;

        public AnonymousMatch(Predicate<ItemToMatch> condition)
        {
            this.condition = condition;
        }

        public bool matches(ItemToMatch item)
        {
            return condition(item);
        }
    }
}