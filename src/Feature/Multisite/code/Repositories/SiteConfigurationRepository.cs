using Sitecore.Basis.Extensions.Extensions;
using Sitecore.Basis.Multisite;
using Sitecore.Basis.Multisite.Providers;
using Sitecore.Data.Items;
using Sitecore.Feature.Multisite.Models;
using Sitecore.Feature.Multisite.Templates;
using System.Collections.Generic;
using System.Linq;

namespace Sitecore.Feature.Multisite.Repositories
{
    public class SiteConfigurationRepository : ISiteConfigurationRepository
    {
        private readonly ISiteDefinitionsProvider siteDefinitionsProvider;

        public SiteConfigurationRepository() : this(new SiteDefinitionsProvider())
        {
        }

        public SiteConfigurationRepository(ISiteDefinitionsProvider itemSiteDefinitionsProvider)
        {
            this.siteDefinitionsProvider = itemSiteDefinitionsProvider;
        }

        public SiteConfigurations Get()
        {
            var siteDefinitions = this.siteDefinitionsProvider.SiteDefinitions;
            return this.Create(siteDefinitions);
        }

        private bool IsValidSiteConfiguration(SiteDefinition siteDefinition)
        {
            return siteDefinition.Item != null && this.IsSiteConfigurationItem(siteDefinition.Item);
        }

        private bool IsSiteConfigurationItem(Item item)
        {
            return item.IsDerived(__SiteConfiguration.TemplateID);
        }

        private SiteConfigurations Create(IEnumerable<SiteDefinition> definitions)
        {
            var siteDefinitions = new SiteConfigurations
            {
                Items = definitions.Where(this.IsValidSiteConfiguration).Select(CreateSiteConfiguration).Where(sc => sc.ShowInMenu)
            };
            return siteDefinitions;
        }

        private static SiteConfiguration CreateSiteConfiguration(SiteDefinition siteConfiguration)
        {
            var title = siteConfiguration.Item[__SiteConfiguration.FieldIds.Title];
            if (string.IsNullOrEmpty(title))
            {
                title = siteConfiguration.Name;
            }
            return new SiteConfiguration
            {
                HostName = siteConfiguration.HostName,
                Name = siteConfiguration.Name,
                Title = title,
                ShowInMenu = siteConfiguration.Item.Fields[__SiteConfiguration.FieldIds.ShowInMenu].IsChecked(),
                IsCurrent = siteConfiguration.IsCurrent
            };
        }
    }
}