using Sitecore.Data.Items;

namespace Sitecore.Basis.Multisite.Providers
{
    public class SourceProvider : ISourceProvider
    {
        private readonly ISiteSettingsProvider siteSettingsProvider;
        public const string SourceSettingsName = "sources";
        private const string QueryPrefix = "query:";

        public SourceProvider() : this(new SiteSettingsProvider())
        {
        }

        public SourceProvider(ISiteSettingsProvider siteSettingsProvider)
        {
            this.siteSettingsProvider = siteSettingsProvider;
        }

        public string GetSource(Item contextItem, string sourceName)
        {
            var sourceSettingItem = this.siteSettingsProvider.GetSetting(contextItem, SourceSettingsName, sourceName);
            if (sourceSettingItem == null)
                return sourceName;
            var sourceRoot = sourceSettingItem?[Templates.SourceConfiguration.FieldIds.Source];
            return (string.IsNullOrEmpty(sourceRoot)) ? sourceName : sourceRoot;
        }
    }
}