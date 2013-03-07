using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Brew.Webforms.Widgets;

public partial class autocomplete : System.Web.UI.Page {
	protected void Page_Load(object sender, EventArgs e) {

		list.SourceList = new List<AutocompleteItem>() {
			new AutocompleteItem { Label = "1", Value = "2" },
			new AutocompleteItem { Label = "3", Value = "4" }
		};

	}
}