using Sitecore.Basis.Extensions.Extensions;
using Sitecore.Data.Items;
using Sitecore.Feature.Identity.Templates;
using System;

namespace Sitecore.Feature.Identity.Repositories
{
    public static class IdentityRepository
    {
        /// <summary>
        /// Get the Identity Item (site root item with Identity info)
        /// </summary>
        /// <param name="contextItem"></param>
        /// <returns></returns>
        public static Item Get([NotNull] Item contextItem)
        {
            if (contextItem == null)
                throw new ArgumentNullException(nameof(contextItem));

            return contextItem.GetAncestorOrSelfOfTemplate(__Identity.TemplateID) ?? Context.Site.GetContextItem(__Identity.TemplateID);
        }
    }
}   