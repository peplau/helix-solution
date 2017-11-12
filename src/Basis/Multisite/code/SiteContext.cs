using Sitecore.Basis.Multisite.Providers;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Basis.Multisite
{
    public class SiteContext
    {
        private readonly ISiteDefinitionsProvider siteDefinitionsProvider;

        public SiteContext() : this(new SiteDefinitionsProvider())
        {
        }

        public SiteContext(ISiteDefinitionsProvider siteDefinitionsProvider)
        {
            this.siteDefinitionsProvider = siteDefinitionsProvider;
        }

        public virtual SiteDefinition GetSiteDefinition([NotNull]Item item)
        {
            Assert.ArgumentNotNull(item, nameof(item));

            return this.siteDefinitionsProvider.GetContextSiteDefinition(item);
        }
    }
}