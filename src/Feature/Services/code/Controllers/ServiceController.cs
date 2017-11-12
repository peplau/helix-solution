using Sitecore.Basis.Alerts.Extensions;
using Sitecore.Basis.Alerts.Models;
using Sitecore.Basis.Dictionary.Repositories;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Sitecore.Feature.Service.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Service()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return Context.PageMode.IsExperienceEditor ? this.InfoMessage(new InfoMessage(DictionaryPhraseRepository.Current.Get("/Service/No Datasource", "No Datasource assigned."), InfoMessage.MessageType.Warning)) : null;
            }

            var item = RenderingContext.Current.Rendering;
            return this.View("Service", item);
        }
    }
}