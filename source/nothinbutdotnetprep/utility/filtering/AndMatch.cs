namespace nothinbutdotnetprep.utility.filtering
{
    public class AndMatch<ItemToMatch> : IMatchAn<ItemToMatch>
    {
        IMatchAn<ItemToMatch> left_side;
        IMatchAn<ItemToMatch> right_side;

        public AndMatch(IMatchAn<ItemToMatch> left_side, IMatchAn<ItemToMatch> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public bool matches(ItemToMatch item)
        {
            return left_side.matches(item) && right_side.matches(item);
        }
    }
}