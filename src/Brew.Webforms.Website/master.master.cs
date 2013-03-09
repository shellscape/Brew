using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master : System.Web.UI.MasterPage {

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		if (this.Page.Request.FilePath.ToLower().Contains("index.aspx")) {
			_source.Visible = false;
			return;
		}

		var content = String.Empty;

		using(var fs = new FileStream(Server.MapPath(this.Page.Request.FilePath), FileMode.Open))
		using (var sr = new StreamReader(fs)) {
			content = sr.ReadToEnd();
		}

		var start = content.IndexOf("</h2>") + "<h2/>".Length;

		content = content.Substring(start);
		content = content.Replace("</asp:content>", String.Empty);
		content = "\t" + content.Trim();
		content = content.Replace("\t", "  "); // tabs to spaces for pretty display on the web

		content = Server.HtmlEncode(content);

		source.Text = content;
	}
}
