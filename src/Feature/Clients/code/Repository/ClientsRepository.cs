using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Feature.Clients.Templates;
using Sitecore.Basis.Extensions.Extensions;

namespace Sitecore.Feature.Clients.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        public IList<__Client> GetClientEntries(Item clients)
        {
            var root = GetRoot(clients);
            return root.Axes.GetDescendants().Where(p => p.IsDerived(__Client.TemplateID)).Select(p => new __Client(p)).ToList();
        }

        public Item GetRoot(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(__Clients.TemplateID) ?? Context.Site.GetContextItem(__Clients.TemplateID);
        }
    }
}