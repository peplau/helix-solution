using Sitecore.Basis.Alerts.Extensions;
using Sitecore.Basis.Alerts.Models;
using Sitecore.Basis.Dictionary.Repositories;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Sitecore.Feature.TeamMember.Controllers
{
    public class TeamMemberController : Controller
    {
        // GET: TeamMember
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return Context.PageMode.IsExperienceEditor
                    ? this.InfoMessage(new InfoMessage(
                            DictionaryPhraseRepository.Current.Get("/TeamMember/No Datasource", "No Datasource assigned"),
                            InfoMessage.MessageType.Warning))
                    : null;
            }

            return View("TeamMember", RenderingContext.Current.Rendering);
        }
    }
}