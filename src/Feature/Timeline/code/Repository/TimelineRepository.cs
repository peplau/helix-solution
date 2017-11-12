using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Feature.Timeline.Templates;
using Sitecore.Basis.Extensions.Extensions;

namespace Sitecore.Feature.Timeline.Repository
{
    public class TimelineRepository : ITimelineRepository
    {
        public Item RootItem { get; }

        public IList<__TimelineEntry> GetTimelineEntries(Item menuItem)
        {
            var root = GetRoot(menuItem);
            return root.Axes.GetDescendants().Where(p => p.IsDerived(__TimelineEntry.TemplateID)).Select(p => new __TimelineEntry(p)).ToList();
        }

        public Item GetRoot(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(__Timeline.TemplateID) ?? Context.Site.GetContextItem(__Timeline.TemplateID);
        }
    }
}