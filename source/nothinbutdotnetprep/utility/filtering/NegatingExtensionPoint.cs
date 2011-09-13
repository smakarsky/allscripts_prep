namespace nothinbutdotnetprep.utility.filtering
{
    public class NegatingExtensionPoint<ItemToFilter, PropertyType> : IProvideAccessToCreatingSpecifications<ItemToFilter,PropertyType>
    {
        IProvideAccessToCreatingSpecifications<ItemToFilter, PropertyType> original_extension_point;

        public NegatingExtensionPoint(IProvideAccessToCreatingSpecifications<ItemToFilter, PropertyType> original_extension_point)
        {
            this.original_extension_point = original_extension_point;
        }

        public IMatchAn<ItemToFilter> create_matcher_from(IMatchAn<PropertyType> real_matcher)
        {
            return original_extension_point.create_matcher_from(real_matcher).not();
        }
    }
}