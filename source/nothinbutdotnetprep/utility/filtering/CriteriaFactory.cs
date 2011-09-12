using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType>
    {
        Func<ItemToMatch, PropertyType> property_accessor;

        public CriteriaFactory(Func<ItemToMatch, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal)
        {
            return new AnonymousMatch<ItemToMatch>(x => property_accessor(x).Equals(value_to_equal));
        }
      
        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] conditions)
        {
          IMatchAn<ItemToMatch> result = null;
          int i = 0;
          foreach (PropertyType condition in conditions)
          {
            i++;
            if (i == 1)
              result = equal_to(condition);
            else
              result = result.or(equal_to(condition));
          }
          return result;
        }
    }
}