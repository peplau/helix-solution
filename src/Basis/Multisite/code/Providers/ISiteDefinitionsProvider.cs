using Sitecore.Data.Items;
using System.Collections.Generic;

namespace Sitecore.Basis.Multisite.Providers
{
    public interface ISiteDefinitionsProvider
    {
        IEnumerable<SiteDefinition> SiteDefinitions { get; }
        SiteDefinition GetContextSiteDefinition(Item item);
    }
}