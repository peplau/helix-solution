using Sitecore.Data.Items;
using Sitecore.Feature.Timeline.Templates;
using System.Collections.Generic;

namespace Sitecore.Feature.Timeline.Repository
{
    public interface ITimelineRepository
    {
        Item GetRoot(Item contextItem);

        IList<__TimelineEntry> GetTimelineEntries(Item timeline);
    }
}
