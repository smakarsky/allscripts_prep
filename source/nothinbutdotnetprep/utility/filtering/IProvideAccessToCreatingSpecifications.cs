namespace nothinbutdotnetprep.utility.filtering
{
    public interface IProvideAccessToCreatingSpecifications<ItemToFilter,PropertyType>
    {
        IMatchAn<ItemToFilter> create_matcher_from(IMatchAn<PropertyType> real_matcher);
    }
}