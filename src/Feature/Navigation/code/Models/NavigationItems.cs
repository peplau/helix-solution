using Sitecore.Mvc.Presentation;
using System.Collections.Generic;

namespace Sitecore.Feature.Navigation.Models
{
    public class NavigationItems : RenderingModel
    {
        public IList<NavigationItem> Items { get; set; }
        public string CssClass { get; set; }
    }
}