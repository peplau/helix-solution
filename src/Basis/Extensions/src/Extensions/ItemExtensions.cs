using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Data.Fields;
using System;
using System.Linq;
using Sitecore.Links;
using Sitecore.Resources.Media;

namespace Sitecore.Basis.Extensions.Extensions
{
    /// <summary>
    /// Extensions for Sitecore Items
    /// </summary>
    public static class ItemExtensions
    {
        /// <summary>
        /// Retrieves an Item of a given template that is the passed Item or one of its ancestors
        /// </summary>
        /// <param name="item"></param>
        /// <param name="templateID"></param>
        /// <returns></returns>
        public static Item GetAncestorOrSelfOfTemplate(this Item item, ID templateID)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return item.IsDerived(templateID) ? item : item.Axes.GetAncestors().LastOrDefault(i => i.IsDerived(templateID));
        }

        /// <summary>
        /// Checks if a given Item is derived from a given TemplateId
        /// </summary>
        /// <param name="item"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public static bool IsDerived(this Item item, ID templateId)
        {
            if (item == null)
            {
                return false;
            }

            return !templateId.IsNull && item.IsDerived(item.Database.Templates[templateId]);
        }

        /// <summary>
        /// Checks if a given Item is derived from a given TemplateItem
        /// </summary>
        /// <param name="item"></param>
        /// <param name="templateItem"></param>
        /// <returns></returns>
        private static bool IsDerived(this Item item, Item templateItem)
        {
            if (item == null)
            {
                return false;
            }

            if (templateItem == null)
            {
                return false;
            }

            var itemTemplate = TemplateManager.GetTemplate(item);
            return itemTemplate != null && (itemTemplate.ID == templateItem.ID || itemTemplate.DescendsFrom(templateItem.ID));
        }

        /// <summary>
        /// Returns true if a given item has version in context language
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool HasContextLanguage(this Item item)
        {
            var latestVersion = item.Versions.GetLatestVersion();
            return latestVersion?.Versions.Count > 0;
        }

        /// <summary>
        /// Get a Target Item a given LinkField or ReferenceField is pointing to
        /// </summary>
        /// <param name="item"></param>
        /// <param name="linkFieldId"></param>
        /// <returns></returns>
        public static Item TargetItem(this Item item, ID linkFieldId)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (item.Fields[linkFieldId] == null || !item.Fields[linkFieldId].HasValue)
                return null;
            return ((LinkField)item.Fields[linkFieldId]).TargetItem ?? ((ReferenceField)item.Fields[linkFieldId]).TargetItem;
        }

        /// <summary>
        /// Get the URL of a given Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string Url(this Item item, UrlOptions options = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (options != null)
                return LinkManager.GetItemUrl(item, options);
            return !item.Paths.IsMediaItem ? LinkManager.GetItemUrl(item) : MediaManager.GetMediaUrl(item);
        }
    }
}