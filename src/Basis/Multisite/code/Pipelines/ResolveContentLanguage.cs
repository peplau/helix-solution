using Sitecore.Configuration;
using Sitecore.Links;
using Sitecore.Pipelines.HttpRequest;

namespace Sitecore.Basis.Multisite.Pipelines
{
    public class ResolveContentLanguage : ExperienceEditor.Pipelines.HttpRequest.ResolveContentLanguage
    {
        private const string DefaultSiteSetting = "Preview.DefaultSite";

        public override void Process(HttpRequestArgs args)
        {
            if (Context.Item == null)
                return;

            var siteContext = LinkManager.GetPreviewSiteContext(Context.Item);

            using (new SettingsSwitcher(DefaultSiteSetting, siteContext.Name))
            {
                base.Process(args);
            }
        }
    }
}