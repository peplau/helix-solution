using Sitecore.Data.Items;

namespace Sitecore.Basis.Multisite.Providers
{
    public interface IDatasourceProvider
    {
        Item[] GetDatasourceLocations(Item contextItem, string name);

        Item GetDatasourceTemplate(Item contextItem, string name);
    }
}