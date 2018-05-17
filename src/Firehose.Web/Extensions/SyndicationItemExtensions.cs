using System.Linq;
using System.ServiceModel.Syndication;

namespace Firehose.Web.Extensions
{
    public static class SyndicationItemExtensions
    {
        public static bool ApplyDefaultFilter(this SyndicationItem item)
        {
            var hasMicrosoftCategory = false;

            if (item.Categories.Count > 0)
                hasMicrosoftCategory = item.Categories.Any(category =>
                    category.Name.ToLowerInvariant().Contains("microsoft"));

            var hasMicrosoftTitle = item.Title?.Text.ToLowerInvariant().Contains("microsoft") ?? false;

            return hasMicrosoftTitle || hasMicrosoftCategory;
        }
    }
}