using Sitecore.Basis.Alerts.Extensions;
using Sitecore.Basis.Alerts.Models;
using Sitecore.Basis.Dictionary.Repositories;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Sitecore.Feature.IntroText.Controllers
{
    public class IntroTextController : Controller
    {
        public ActionResult IntroText()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return Context.PageMode.IsExperienceEditor ? this.InfoMessage(new InfoMessage(DictionaryPhraseRepository.Current.Get("/Intro Text/No Datasource", "No Datasource assigned"), InfoMessage.MessageType.Warning)) : null;
            }
            var item = RenderingContext.Current.Rendering;
            return this.View("IntroText", item);
        }
    }
}