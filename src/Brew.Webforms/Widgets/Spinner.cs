using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Brew;
using Brew.TypeConverters;

namespace Brew.Webforms.Widgets {

	/// <summary>
	/// Extend a TextBox or input text element with the jQuery UI Spinner http://api.jqueryui.com/spinner/
	/// </summary>
	public class Spinner : Widget, IAutoPostBack {

		public Spinner() : base("spinner") {		}

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("create"),
				new WidgetEvent("start"),
				new WidgetEvent("spin"),
				new WidgetEvent("stop"),
				new WidgetEvent("change") { CausesPostBack = true, DataChangedEvent = true }
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "culture", DefaultValue = null },
				new WidgetOption { Name = "icons", DefaultValue = "{ down: \"ui-icon-triangle-1-s\", up: \"ui-icon-triangle-1-n\" }" },
				new WidgetOption { Name = "incremental", DefaultValue = false },
				new WidgetOption { Name = "max", DefaultValue = null },
				new WidgetOption { Name = "min", DefaultValue = null },
				new WidgetOption { Name = "numberFormat", DefaultValue = null },
				new WidgetOption { Name = "page", DefaultValue = null },
				new WidgetOption { Name = "step", DefaultValue = null }
			};
		}

		/// <summary>
		/// This event is triggered when the value of the spinner changes.
		/// Reference: http://api.jqueryui.com/spinner/#event-change
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered when the value of the spinner changes.")]
		public event EventHandler ValueChanged;

		#region .    Options    .

		/// <summary>
		/// Sets the culture to use for parsing and formatting the value.
		/// Reference: http://api.jqueryui.com/spinner/#option-icons
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Sets the culture to use for parsing and formatting the value.")]
		public string Culture { get; set; }

		/// <summary>
		/// Icons to use for buttons, matching an icon defined by the jQuery UI CSS Framework.
		/// Reference: http://api.jqueryui.com/spinner/#option-icons
		/// </summary>
		[TypeConverter(typeof(Brew.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{ down: \"ui-icon-triangle-1-s\", up: \"ui-icon-triangle-1-n\" }")]
		[Description("Icons to use for buttons, matching an icon defined by the jQuery UI CSS Framework.")]
		public string Icons { get; set; }

		/// <summary>
		/// Controls the number of steps taken when holding down a spin button.
		/// Reference: http://api.jqueryui.com/spinner/#option-incremental
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Controls the number of steps taken when holding down a spin button.")]
		public bool Incremental { get; set; }

		/// <summary>
		/// The maximum allowed value. The element's max attribute is used if it exists and the option is not explicitly set. If null, there is no maximum enforced.
		/// Reference: http://api.jqueryui.com/spinner/#option-max
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The maximum allowed value. The element's max attribute is used if it exists and the option is not explicitly set. If null, there is no maximum enforced.")]
		public dynamic Max { get; set; }

		/// <summary>
		/// The minimum allowed value. The element's min attribute is used if it exists and the option is not explicitly set. If null, there is no minimum enforced.
		/// Reference: http://api.jqueryui.com/spinner/#option-min
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The minimum allowed value. The element's min attribute is used if it exists and the option is not explicitly set. If null, there is no minimum enforced.")]
		public dynamic Min { get; set; }

		/// <summary>
		/// Format of numbers passed to Globalize, if available.
		/// Reference: http://api.jqueryui.com/spinner/#option-numberFormat
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Format of numbers passed to Globalize, if available.")]
		public string NumberFormat { get; set; }

		/// <summary>
		/// The number of steps to take when paging via the pageUp/pageDown methods.
		/// Reference: http://api.jqueryui.com/spinner/#option-numberFormat
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The number of steps to take when paging via the pageUp/pageDown methods.")]
		// Can't name this "Page" without messing with the Control.Page property. Would be messy if anyone tried inheriting.
		public int? PageSteps { get; set; }

		/// <summary>
		/// The size of the step to take when spinning via buttons or via the stepUp()/stepDown() methods.
		/// Reference: http://api.jqueryui.com/spinner/#option-min
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The size of the step to take when spinning via buttons or via the stepUp()/stepDown() methods.")]
		public dynamic Step { get; set; }

		#endregion

	}
}