using Sitecore.Data.Items;
using Sitecore.Feature.Navigation.Models;

namespace Sitecore.Feature.Navigation.Repositories
{
    public interface INavigationRepository
    {
        Item GetNavigationRoot(Item contextItem);
        NavigationItems GetLinkMenuItems(Item menuItem);
    }
}
