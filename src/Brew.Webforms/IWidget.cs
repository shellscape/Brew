using System;
using System.Web.UI;
using System.Collections.Generic;

namespace Brew.Webforms {

	public interface IWidget {

		Page Page { get; }
		IDictionary<string, object> WidgetOptions { get; set; }

		string ClientID { get; }
		string UniqueID { get; }
		string WidgetName { get; }
		string TargetClientID { get; }

		bool AutoPostBack { get; set; }
		bool Disabled { get; set; }
		bool Visible { get; }

		void SaveWidgetOptions();

	}

	public interface IWidget2 {

		Page Page { get; }
		IDictionary<String, object> Options { get; set; }

		String ClientID { get; }
		String UniqueID { get; }
		String Name { get; }
		Control TargetControl { get; }
		String @For { get; set; }

		bool AutoPostBack { get; set; }
		bool Disabled { get; set; }
		bool Visible { get; }
		
		void SaveOptions();

	}
}