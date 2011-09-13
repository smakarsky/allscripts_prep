using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class FilteringExtensionPoint<ItemToFilter,PropertyType> : IProvideAccessToCreatingSpecifications<ItemToFilter,PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;

        public FilteringExtensionPoint(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public IProvideAccessToCreatingSpecifications<ItemToFilter,PropertyType>  not
        {
            get
            {
                return new NegatingExtensionPoint<ItemToFilter, PropertyType>(this);
            }
        }

        public IMatchAn<ItemToFilter> create_matcher_from(IMatchAn<PropertyType> real_matcher)
        {
            return new PropertyMatch<ItemToFilter, PropertyType>(property_accessor,
                                                                 real_matcher);
        }
    }
}