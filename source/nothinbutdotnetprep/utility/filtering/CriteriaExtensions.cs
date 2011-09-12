namespace nothinbutdotnetprep.utility.filtering
{
    public static class CriteriaExtensions
    {
        public static IMatchAn<Item> not<Item>(this IMatchAn<Item> to_negate)
        {
            return new NegatingMatch<Item>(to_negate);
        }

        public static IMatchAn<Item> or<Item>(this IMatchAn<Item> left_side,
                                              IMatchAn<Item> right_side)
        {
            return new OrMatch<Item>(left_side, right_side);
        }
    }
}