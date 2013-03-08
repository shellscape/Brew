using System;
using System.Web.UI;
using System.Collections.Generic;

namespace Brew.Webforms {

	public interface IWidget {

		Page Page { get; }

		String ClientID { get; }
		String UniqueID { get; }
		String Name { get; }
		Control TargetControl { get; }
		String @For { get; set; }

		bool AutoPostBack { get; set; }
		bool Disabled { get; set; }
		bool Visible { get; }
	}
}