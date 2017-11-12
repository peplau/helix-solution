using Sitecore.Basis.Alerts.Extensions;
using Sitecore.Basis.Alerts.Models;
using Sitecore.Basis.Dictionary.Repositories;
using Sitecore.Feature.Timeline.Repository;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Sitecore.Feature.Timeline.Controllers
{
    public class TimelineController : Controller
    {
        private readonly ITimelineRepository _timelineRepository;

        public TimelineController()
        {
            _timelineRepository = new TimelineRepository();
        }

        // GET: Timeline
        public ActionResult Timeline()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return Context.PageMode.IsExperienceEditor ? this.InfoMessage(new InfoMessage(DictionaryPhraseRepository.Current.Get("/Timeline/No Datasource", "No Datasource assigned"), InfoMessage.MessageType.Warning)) : null;
            }

            var model = new Models.Timeline()
            {
                Entries = _timelineRepository.GetTimelineEntries(RenderingContext.Current.Rendering.Item)
            };
            
            return this.View("Timeline", model);
        }
    }
}