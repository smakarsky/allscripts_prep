namespace nothinbutdotnetprep.utility.filtering
{
    public interface IMatchAn<ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }
}