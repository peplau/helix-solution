using Sitecore.Basis.Multisite.Providers;
using Sitecore.Basis.Multisite.Templates;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;
using System.Collections.Specialized;

namespace Sitecore.Basis.Multisite.Commands
{
    public class CreateRenderingSettings : Command
    {
        private const string DatasourceLocationFieldName = "Datasource Location";

        public override void Execute(CommandContext context)
        {
            var parameters = new NameValueCollection();
            var parentId = context.Parameters["parentID"];
            if (string.IsNullOrEmpty(parentId))
            {
                var item = context.Items[0];
                parentId = item.ID.ToString();
            }
            parameters.Add("item", parentId);
            Context.ClientPage.Start(this, "Run", parameters);
        }

        public void Run(ClientPipelineArgs args)
        {
            if (!args.IsPostBack)
            {
                ShowDatasourceSettingsDialog();
                args.WaitForPostBack();
            }
            else
            {
                if (!args.HasResult)
                {
                    return;
                }
                var itemId = ID.Parse(args.Parameters["item"]);
                CreateDatasourceConfigurationItem(itemId, args.Result);
            }
        }

        private static void CreateDatasourceConfigurationItem(ID contextItemId, string renderingItemId)
        {
            var contextItem = Context.ContentDatabase.GetItem(contextItemId);
            if (contextItem == null)
            {
                return;
            }

            var renderingItem = Context.ContentDatabase.GetItem(renderingItemId);
            if (renderingItem == null)
            {
                return;
            }

            var datasourceConfigurationName = GetDatasourceConfigurationName(renderingItem);

            contextItem.Add(datasourceConfigurationName, new TemplateID(DatasourceConfiguration.TemplateID));
        }

        private static string GetDatasourceConfigurationName(Item renderingItem)
        {
            var datasourceLocationValue = renderingItem[DatasourceLocationFieldName];
            var datasourceConfigurationName = DatasourceConfigurationService.GetSiteDatasourceConfigurationName(datasourceLocationValue);
            if (string.IsNullOrEmpty(datasourceConfigurationName))
            {
                datasourceConfigurationName = renderingItem.Name;
            }
            return datasourceConfigurationName;
        }

        private static void ShowDatasourceSettingsDialog()
        {
            var urlString = new UrlString(Context.Site.XmlControlPage)
            {
                ["xmlcontrol"] = "DatasourceSettings"
            };
            var dialogOptions = new ModalDialogOptions(urlString.ToString())
            {
                Response = true
            };
            SheerResponse.ShowModalDialog(dialogOptions);
        }
    }
}