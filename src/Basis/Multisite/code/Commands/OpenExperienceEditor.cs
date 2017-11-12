using Sitecore.Configuration;
using Sitecore.Sites;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.Basis.Multisite.Commands
{
    public class OpenExperienceEditor : Shell.Applications.WebEdit.Commands.OpenExperienceEditor
    {
        private const string DefaultSiteSetting = "Preview.DefaultSite";

        public new void Run(ClientPipelineArgs args)
        {
            var hostName = WebUtil.GetHostName();
            var site = SiteContextFactory.GetSiteContext(hostName, "/");
            var siteName = site?.Name ?? Settings.Preview.DefaultSite;

            using (new SettingsSwitcher(DefaultSiteSetting, siteName))
            {
                base.Run(args);
            }
        }
    }
}