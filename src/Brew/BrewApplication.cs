using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Web.UI;

using Brew;

[assembly: System.Web.PreApplicationStartMethod(typeof(Brew.BrewApplication), "Start")]

namespace Brew {

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class BrewApplication {

		public static void Start() {

			ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
					new ScriptResourceDefinition {
						Path = "~/Scripts/jquery-1.8.2.min.js",
						DebugPath = "~/Scripts/jquery-1.8.2.js",
						CdnPath = "http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js",
						CdnDebugPath = "http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.js",
						CdnSupportsSecureConnection = true
					}
			);

			ScriptManager.ScriptResourceMapping.AddDefinition("jquery-ui",
					new ScriptResourceDefinition {
						Path = "~/Scripts/jquery-ui-1.9.0.min.js",
						DebugPath = "~/Scripts/jquery-ui-1.9.0.js",
						CdnPath = "http://code.jquery.com/ui/1.9.0/jquery-ui.min.js",
						CdnDebugPath = "http://code.jquery.com/ui/1.9.0/jquery-ui.js",
						CdnSupportsSecureConnection = true
					}
			);

			ScriptManager.ScriptResourceMapping.AddDefinition("brew",
					new ScriptResourceDefinition {
						Path = "~/Scripts/brew.js",
						DebugPath = "~/Scripts/brew.js"
					}
			);
		}

		public static IEnumerable<ScriptReference> GetReferences() {
			return new List<ScriptReference> {
				new ScriptReference("jquery", null),
				new ScriptReference("jquery-ui", null),
				new ScriptReference("brew", null)
			};
		}
	}
}