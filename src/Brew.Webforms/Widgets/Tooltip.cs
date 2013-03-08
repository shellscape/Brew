using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;

using Brew;
using Brew.TypeConverters;

namespace Brew.Webforms.Widgets {

	/// <summary>
	/// Extend a WebControl or HtmlControl with jQuery UI Draggable http://jqueryui.com/demos/draggable/
	/// </summary>
	public class Tooltip : Widget {

		public Tooltip() : base("tooltip") { }

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("create"),
				new WidgetEvent("open"),
				new WidgetEvent("close")
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "content", DefaultValue = null },
				new WidgetOption { Name = "hide", DefaultValue = null },
				new WidgetOption { Name = "items", DefaultValue = "[title]", PropertyName = "ItemsSelector" },
				new WidgetOption { Name = "position", DefaultValue = "{ my: \"left+15 center\", at: \"right center\", collision: \"flipfit\" }" },
				new WidgetOption { Name = "show", DefaultValue = null },
				new WidgetOption { Name = "tooltipClass", DefaultValue = null },
				new WidgetOption { Name = "track", DefaultValue = false }
			};
		}

		#region .    Options    .

		/// <summary>
		/// The content of the tooltip.
		/// When changing this option, you likely need to also change the ItemsSelector Property.
		/// Reference: http://api.jqueryui.com/tooltip/#option-content
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The content of the tooltip. When changing this option, you likely need to also change the ItemsSelector Property.")]
		// TODO: this can be a function or string, and is a function by default.
		// need to figure out how to convert this.
		public String Content { get; set; }

		/// <summary>
		/// If and how to animate the hiding of the tooltip..
		/// Reference: http://api.jqueryui.com/tooltip/#option-hide
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("If and how to animate the hiding of the tooltip.")]
		public dynamic Hide { get; set; }

		/// <summary>
		/// A selector indicating which items should show tooltips. Customize if you're using something other then the title attribute for the tooltip content, or if you need a different selector for event delegation.
		/// Reference: http://api.jqueryui.com/tooltip/#option-items
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("A selector indicating which items should show tooltips. Customize if you're using something other then the title attribute for the tooltip content, or if you need a different selector for event delegation.")]
		public string ItemsSelector { get; set; }

		/// <summary>
		/// CConfiguration for the Position utility. The "of" property defaults to the target element, but can also be overriden.
		/// Reference: http://api.jqueryui.com/tooltip/#option-position
		/// </summary>
		[TypeConverter(typeof(Brew.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{}")]
		[Description("Configuration for the Position utility. The \"of\" property defaults to the target element, but can also be overriden.")]
		public string Position { get; set; }

		/// <summary>
		/// If and how to animate the showing of the tooltip..
		/// Reference: http://api.jqueryui.com/tooltip/#option-show
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("If and how to animate the showing of the tooltip.")]
		public dynamic Show { get; set; }

		/// <summary>
		/// A class to add to the widget, can be used to display various tooltip types, like warnings or errors.
		/// Reference: http://api.jqueryui.com/tooltip/#option-tooltipClass
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("A class to add to the widget, can be used to display various tooltip types, like warnings or errors.")]
		public string TooltipClass { get; set; }

		/// <summary>
		/// Whether the tooltip should track (follow) the mouse.
		/// Reference: http://api.jqueryui.com/spinner/#option-incremental
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Whether the tooltip should track (follow) the mouse.")]
		public bool Track { get; set; }

		#endregion

	}
}
