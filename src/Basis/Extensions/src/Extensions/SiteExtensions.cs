using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Sites;
using Sitecore.Xml.Xsl;
using System;

namespace Sitecore.Basis.Extensions.Extensions
{
    /// <summary>
    /// Extensions for Sitecore Sites
    /// </summary>
    public static class SiteExtensions
    {
        /// <summary>
        /// Retrieves the ContextItem of a given Site derived from a given TemplateId
        /// </summary>
        /// <param name="site"></param>
        /// <param name="derivedFromTemplateID"></param>
        /// <returns></returns>
        public static Item GetContextItem(this SiteContext site, ID derivedFromTemplateID)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            var startItem = site.GetStartItem();
            return startItem?.GetAncestorOrSelfOfTemplate(derivedFromTemplateID);
        }

        /// <summary>
        /// Get the item the Start Item of a given Site
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public static Item GetStartItem(this SiteContext site)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            return site.Database.GetItem(Context.Site.StartPath);
        }

        /// <summary>
        /// Get the URL of a given Link field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldID"></param>
        /// <returns></returns>
        public static string LinkFieldUrl(this Item item, ID fieldID)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (ID.IsNullOrEmpty(fieldID))
            {
                throw new ArgumentNullException(nameof(fieldID));
            }
            var field = item.Fields[fieldID];
            if (field == null)
            {
                return string.Empty;
            }
            var linkUrl = new LinkUrl();
            return linkUrl.GetUrl(item, fieldID.ToString());
        }

        /// <summary>
        /// Get the TARGET of a given Link field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldID"></param>
        /// <returns></returns>
        public static string LinkFieldTarget(this Item item, ID fieldID)
        {
            return item.LinkFieldOptions(fieldID, LinkFieldOption.Target);
        }

        /// <summary>
        /// Get the OPTIONS of a given Link field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldID"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static string LinkFieldOptions(this Item item, ID fieldID, LinkFieldOption option)
        {
            XmlField field = item.Fields[fieldID];
            switch (option)
            {
                case LinkFieldOption.Text:
                    return field?.GetAttribute("text");
                case LinkFieldOption.LinkType:
                    return field?.GetAttribute("linktype");
                case LinkFieldOption.Class:
                    return field?.GetAttribute("class");
                case LinkFieldOption.Alt:
                    return field?.GetAttribute("title");
                case LinkFieldOption.Target:
                    return field?.GetAttribute("target");
                case LinkFieldOption.QueryString:
                    return field?.GetAttribute("querystring");
                default:
                    throw new ArgumentOutOfRangeException(nameof(option), option, null);
            }
        }
    }

    /// <summary>
    /// Enum with possible options of a LinkField
    /// </summary>
    public enum LinkFieldOption
    {
        Text,
        LinkType,
        Class,
        Alt,
        Target,
        QueryString
    }
}