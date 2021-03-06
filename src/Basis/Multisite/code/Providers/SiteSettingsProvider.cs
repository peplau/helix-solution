﻿using Sitecore.Basis.Extensions.Extensions;
using Sitecore.Configuration;
using Sitecore.Data.Items;
using System.Linq;

namespace Sitecore.Basis.Multisite.Providers
{
    public class SiteSettingsProvider : ISiteSettingsProvider
    {
        private readonly SiteContext siteContext;

        public SiteSettingsProvider() : this(new SiteContext())
        {
        }

        public SiteSettingsProvider(SiteContext siteContext)
        {
            this.siteContext = siteContext;
        }

        public static string SettingsRootName => Settings.GetSetting("Multisite.SettingsRootName", "settings");

        public virtual Item GetSetting(Item contextItem, string settingsName, string setting)
        {
            var settingsRootItem = this.GetSettingsRoot(contextItem, settingsName);
            var settingItem = settingsRootItem?.Children.FirstOrDefault(i => i.Key.Equals(setting.ToLower()));
            return settingItem;
        }

        private Item GetSettingsRoot(Item contextItem, string settingsName)
        {
            var currentDefinition = this.siteContext.GetSiteDefinition(contextItem);
            if (currentDefinition?.Item == null)
            {
                return null;
            }

            var definitionItem = currentDefinition.Item;
            var settingsFolder = definitionItem.Children[SettingsRootName];
            var settingsRootItem = settingsFolder?.Children.FirstOrDefault(i => i.IsDerived(Templates.__SiteSettings.TemplateID) && i.Key.Equals(settingsName.ToLower()));
            return settingsRootItem;
        }
    }
}