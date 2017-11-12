using Sitecore.Data.Items;

namespace Sitecore.Basis.Multisite.Providers
{
    public interface ISourceProvider
    {
        string GetSource(Item contextItem, string name);
    }
}
