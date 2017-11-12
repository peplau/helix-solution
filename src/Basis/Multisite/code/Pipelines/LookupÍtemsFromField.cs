using Sitecore.Basis.Multisite.Providers;
using Sitecore.Basis.Multisite.Templates;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Pipelines.GetLookupSourceItems;
using Sitecore.Shell.Applications.ContentEditor;
using Sitecore.Text;
using Sitecore.Web;
using System;
using System.Linq;

namespace Sitecore.Basis.Multisite.Pipelines
{
    public class LookupÍtemsFromField
    {
        private const string scapePrefix = "site:";
        private readonly ISourceProvider provider;
        private ID BaseParameterTemplate = StandardRenderingParameters.TemplateID;

        public LookupÍtemsFromField() : this(new SourceProvider())
        {
        }

        public LookupÍtemsFromField(ISourceProvider provider)
        {
            this.provider = provider;
        }

        public void Process(GetLookupSourceItemsArgs args)
        {
            if (!args.Source.Contains(scapePrefix))
                return;

            Item contextItem;
            // Only goes ahead if this is a Parameters Template
            if (args.Item.Template.BaseTemplates.Where(bt => bt.ID == BaseParameterTemplate).Any())
            {
                // This whole block is to get Context Item
                string url = WebUtil.GetQueryString();
                if (string.IsNullOrWhiteSpace(url))
                {
                    args.Source = String.Empty;
                    return;
                }

                FieldEditorParameters parameters = null;
                try
                {
                    parameters = FieldEditorOptions.Parse(new UrlString(url)).Parameters;
                }
                catch (Exception) { }
                if (parameters == null)
                {
                    args.Source = String.Empty;
                    return;
                }
                var currentItemId = parameters["contentitem"];
                if (string.IsNullOrEmpty(currentItemId))
                {
                    args.Source = String.Empty;
                    return;
                }
                ItemUri contentItemUri = new ItemUri(currentItemId);
                contextItem = Database.GetItem(contentItemUri);
            }
            else
            {
                contextItem = args.Item;
            }

            // Now to the custom (site-specific) parameters
            var sourceName = args.Source.Replace(scapePrefix, "").Trim();
            args.Source = provider.GetSource(contextItem, sourceName);
        }
    }
}