using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class CustomDateFilteringExtensions
    {
        public static IMatchAn<ItemToMatch> greater_than<ItemToMatch>(
            this IProvideAccessToCreatingSpecifications<ItemToMatch,DateTime> extension_point, int year)
        {
            return extension_point.create_matcher_from(new AnonymousMatch<DateTime>(x => x.Year > year));
        }
    }

}