using Sitecore.Data.Items;
using Sitecore.Feature.Clients.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Feature.Clients.Repository
{
    public interface IClientsRepository
    {
        Item GetRoot(Item contextItem);

        IList<__Client> GetClientEntries(Item clients);
    }
}
