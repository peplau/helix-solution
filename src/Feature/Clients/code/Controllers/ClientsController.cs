using Sitecore.Basis.Alerts.Extensions;
using Sitecore.Basis.Alerts.Models;
using Sitecore.Basis.Dictionary.Repositories;
using Sitecore.Feature.Clients.Repository;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Sitecore.Feature.Clients.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsController()
        {
            _clientsRepository = new ClientsRepository();
        }

        // GET: Clients
        public ActionResult Clients()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return Context.PageMode.IsExperienceEditor ? this.InfoMessage(new InfoMessage(DictionaryPhraseRepository.Current.Get("/Clients/No Datasource", "No Datasource assigned"), InfoMessage.MessageType.Warning)) : null;
            }

            var model = new Models.Clients()
            {
                ClientList = _clientsRepository.GetClientEntries(RenderingContext.Current.Rendering.Item)
            };

            return this.View("Clients", model);
        }
    }
}