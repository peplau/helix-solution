using Sitecore.Sites;

namespace Sitecore.Basis.Dictionary.Repositories
{
    public interface IDictionaryRepository
    {
        Models.Dictionary Get(SiteContext site);
    }
}