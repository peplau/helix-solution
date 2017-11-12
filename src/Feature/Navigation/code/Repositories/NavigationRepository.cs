using System;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Feature.Navigation.Models;
using Sitecore.Basis.Extensions.Extensions;
using Sitecore.Feature.Navigation.Templates;

namespace Sitecore.Feature.Navigation.Repositories
{
    /// <summary>
    /// Repository of Navigation items
    /// </summary>
    public class NavigationRepository : INavigationRepository
    {
        public Item ContextItem { get; }
        public Item NavigationRoot { get; }

        /// <summary>
        /// Will load ContextItem and NavigationRoot
        /// </summary>
        /// <param name="contextItem"></param>
        public NavigationRepository(Item contextItem)
        {
            this.ContextItem = contextItem;
            this.NavigationRoot = this.GetNavigationRoot(this.ContextItem);
            if (this.NavigationRoot == null)
            {
                throw new InvalidOperationException($"Cannot determine navigation root from '{this.ContextItem.Paths.FullPath}'");
            }
        }

        /// <summary>
        /// Get the Link Menu items from a given MenuRoot
        /// </summary>
        /// <param name="menuRoot"></param>
        /// <returns></returns>
        public NavigationItems GetLinkMenuItems(Item menuRoot)
        {
            if (menuRoot == null)
            {
                throw new ArgumentNullException(nameof(menuRoot));
            }
            return this.GetChildNavigationItems(menuRoot, 0, 0);
        }

        private NavigationItems GetChildNavigationItems(Item parentItem, int level, int maxLevel)
        {
            if (level > maxLevel || !parentItem.HasChildren)
            {
                return null;
            }
            var childItems = parentItem.Children.Where(item => this.IncludeInNavigation(item)).Select(i => this.CreateNavigationItem(i, level, maxLevel));
            return new NavigationItems
            {
                Items = childItems.ToList()
            };
        }

        private NavigationItem CreateNavigationItem(Item item, int level, int maxLevel = -1)
        {
            var targetItem = item.IsDerived(__Link.TemplateID) ? item.TargetItem(__Link.FieldIds.Link) : item;
            return new NavigationItem
            {
                Item = item,
                Url = item.IsDerived(__Link.TemplateID) ? item.LinkFieldUrl(__Link.FieldIds.Link) : item.Url(),
                Target = item.IsDerived(__Link.TemplateID) ? item.LinkFieldTarget(__Link.FieldIds.Link) : "",
                IsActive = this.IsItemActive(targetItem ?? item),
                Children = this.GetChildNavigationItems(item, level + 1, maxLevel),
                //ShowChildren = !item.IsDerived(__Navigable.TemplateID) || item.Fields[__Navigable.FieldIds.ShowChildren].IsChecked()
            };
        }

        private bool IncludeInNavigation(Item item, bool forceShowInMenu = false)
        {
            return item.HasContextLanguage() && item.IsDerived(__Navigable.TemplateID) && (forceShowInMenu || MainUtil.GetBool(item[__Navigable.FieldIds.ShowInNavigation], false));
        }

        /// <summary>
        /// Will retrieve the Navigation Root Item from a given Item
        /// </summary>
        /// <param name="contextItem"></param>
        /// <returns></returns>
        public Item GetNavigationRoot(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(__NavigationRoot.TemplateID) ?? Context.Site.GetContextItem(__NavigationRoot.TemplateID);
        }

        private bool IsItemActive(Item item)
        {
            return this.ContextItem.ID == item.ID || this.ContextItem.Axes.GetAncestors().Any(a => a.ID == item.ID);
        }
    }
}