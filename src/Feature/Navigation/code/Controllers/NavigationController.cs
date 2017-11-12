using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Basis.Alerts.Extensions;
using Sitecore.Basis.Alerts.Models;
using Sitecore.Basis.Dictionary.Repositories;
using Sitecore.Feature.Navigation.Repositories;
using Sitecore.Feature.Navigation.Templates;

namespace Sitecore.Feature.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        private readonly INavigationRepository _navigationRepository;

        public NavigationController() : this(new NavigationRepository(RenderingContext.Current.ContextItem))
        {
        }

        public NavigationController(INavigationRepository navigationRepository)
        {
            this._navigationRepository = navigationRepository;
        }

        public ActionResult LinkMenu()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return Context.PageMode.IsExperienceEditor ? this.InfoMessage(new InfoMessage(DictionaryPhraseRepository.Current.Get("/Navigation/Link Menu/No Items", "This menu has no items."), InfoMessage.MessageType.Warning)) : null;
            }

            var item = RenderingContext.Current.Rendering.Item;
            var items = this._navigationRepository.GetLinkMenuItems(item);
            items.CssClass = RenderingContext.Current.Rendering.Parameters.Contains(ParametersTemplate_CssClass.FieldNames.CSSClass) 
                ? RenderingContext.Current.Rendering.Parameters[ParametersTemplate_CssClass.FieldNames.CSSClass] 
                : string.Empty;

            return this.View("LinkMenu", items);
        }

        public ActionResult MainMenu()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                return Context.PageMode.IsExperienceEditor ? this.InfoMessage(new InfoMessage(DictionaryPhraseRepository.Current.Get("/Navigation/Main Menu/No Items", "This menu has no items."), InfoMessage.MessageType.Warning)) : null;
            }

            var item = RenderingContext.Current.Rendering.Item;
            var items = this._navigationRepository.GetLinkMenuItems(item);

            return this.View("MainMenu", items);
        }
    }
}