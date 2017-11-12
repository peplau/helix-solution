using Sitecore.Feature.Multisite.Repositories;
using System.Web.Mvc;

namespace Sitecore.Feature.Multisite.Controllers
{
    public class MultisiteController : Controller
    {
        private readonly ISiteConfigurationRepository multisiteRepository;

        public MultisiteController() : this(new SiteConfigurationRepository())
        {
        }

        public MultisiteController(ISiteConfigurationRepository multisiteRepository)
        {
            this.multisiteRepository = multisiteRepository;
        }

        public ActionResult SwitchSite()
        {
            var definitions = this.multisiteRepository.Get();
            return this.View(definitions);
        }

    }
}