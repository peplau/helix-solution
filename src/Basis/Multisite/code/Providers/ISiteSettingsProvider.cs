using Sitecore.Data.Items;

namespace Sitecore.Basis.Multisite.Providers
{
    public interface ISiteSettingsProvider
    {
        Item GetSetting(Item contextItem, string settingsType, string setting);
    }
}