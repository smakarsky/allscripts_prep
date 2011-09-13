using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public interface IAnonymousMatch<ItemToMatch>
    {
        IMatchAn<ItemToMatch>  CreateAnonymousMatch(Predicate<ItemToMatch> property_accessor_value);
    }

    public class AnonymousMatch<ItemToMatch> : IMatchAn<ItemToMatch>, IAnonymousMatch<ItemToMatch>
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

        public IMatchAn<ItemToMatch> CreateAnonymousMatch(Predicate<ItemToMatch> property_accessor_value)
        {
            return new AnonymousMatch<ItemToMatch>(property_accessor_value);
        }
    }
}