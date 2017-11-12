using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitecore.Common.Website.Web.UI.Controls
{
    public class CustomSingleLineText : Sitecore.Form.Web.UI.Controls.SingleLineText
    {
        protected override void OnInit(EventArgs e)
        {
            this.textbox.CssClass = "scfSingleLineTextBox";
            this.help.CssClass = "scfSingleLineTextUsefulInfo";
            this.generalPanel.CssClass = "scfSingleLineGeneralPanel";
            this.title.CssClass = "scfSingleLineTextLabel";
            this.textbox.TextMode = TextBoxMode.SingleLine;
            this.Controls.AddAt(0, (Control)this.generalPanel);
            this.Controls.AddAt(0, (Control)this.title);
            this.generalPanel.Controls.AddAt(0, (Control)this.help);
            this.generalPanel.Controls.AddAt(0, (Control)this.textbox);
        }
    }
}