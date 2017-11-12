using Sitecore.Basis.Alerts.Extensions;
using Sitecore.Basis.Alerts.Models;
using Sitecore.Basis.Dictionary.Repositories;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Sitecore.Feature.BoxWithModal.Controllers
{
    public class BoxWithModalController : Controller
    {
        public ActionResult Box()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return Context.PageMode.IsExperienceEditor ? this.InfoMessage(new InfoMessage(DictionaryPhraseRepository.Current.Get("/BoxWithModal/Box/No Datasource", "No Datasource assigned"), InfoMessage.MessageType.Warning)) : null;
            }

            var item = RenderingContext.Current.Rendering;
            return this.View("Box", item);
        }
        public ActionResult Modal()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return Context.PageMode.IsExperienceEditor ? this.InfoMessage(new InfoMessage(DictionaryPhraseRepository.Current.Get("/BoxWithModal/Modal/No Datasource", "No Datasource assigned"), InfoMessage.MessageType.Warning)) : null;
            }

            var item = RenderingContext.Current.Rendering;
            return this.View("Modal", item);
        }
    }
}