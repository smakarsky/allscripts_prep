namespace nothinbutdotnetprep.utility.filtering
{
    public static class CriteriaExtensions
    {
        public static IMatchAn<Item> or<Item>(this IMatchAn<Item> left_side,
                                              IMatchAn<Item> right_side)
        {
            return new OrMatch<Item>(left_side, right_side);
        }
    }
}