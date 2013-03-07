using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Brew;

namespace Brew.Webforms.Widgets {

	/// <summary>
	/// Extend a Control with the jQuery UI Selectable behavior http://api.jqueryui.com/selectable/
	/// </summary>
	public class Selectable : Widget {

		public Selectable() : base("selectable") { }

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
			new WidgetEvent("create"),
			new WidgetEvent("selecting"),
			new WidgetEvent("start"),
			new WidgetEvent("stop"),
			new WidgetEvent("unselecting"),
			new WidgetEvent("selected") { CausesPostBack = true },
			new WidgetEvent("unselected") { CausesPostBack = true }
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "autoRefresh", DefaultValue = true },
				new WidgetOption { Name = "cancel", DefaultValue = ":input,option" },
				new WidgetOption { Name = "delay", DefaultValue = 0 },
				new WidgetOption { Name = "distance", DefaultValue = 0 },
				new WidgetOption { Name = "filter", DefaultValue = "*" },
				new WidgetOption { Name = "tolerance", DefaultValue = "touch" }
			};
		}

		/// <summary>
		/// This event is triggered at the end of the select operation, on each element added to the selection.
		/// Reference: http://api.jqueryui.com/selectable/#event-selected
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered at the end of the select operation, on each element added to the selection.")]
		public event EventHandler Selected;

		/// <summary>
		/// This event is triggered at the end of the select operation, on each element removed from the selection.
		/// Reference: http://api.jqueryui.com/selectable/#event-unselected
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered at the end of the select operation, on each element removed from the selection.")]
		public event EventHandler Unselected;

		#region .    Options    .

		/// <summary>
		/// This determines whether to refresh (recalculate) the position and size of each selectee at the beginning of each select operation. If you have many many items, you may want to set this to false and call the refresh method manually.
		/// Reference: http://api.jqueryui.com/selectable/#option-autoRefresh
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("This determines whether to refresh (recalculate) the position and size of each selectee at the beginning of each select operation. If you have many many items, you may want to set this to false and call the refresh method manually.")]
		public bool AutoRefresh { get; set; }

		/// <summary>
		/// Prevents selecting if you start on elements matching the selector.
		/// Reference: http://api.jqueryui.com/selectable/#option-cancel
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(":input,option")]
		[Description("Prevents selecting if you start on elements matching the selector.")]
		public string Cancel { get; set; }

		/// <summary>
		/// Time in milliseconds to define when the selecting should start. It helps preventing unwanted selections when clicking on an element.
		/// Reference: http://api.jqueryui.com/selectable/#option-delay
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Time in milliseconds to define when the selecting should start. It helps preventing unwanted selections when clicking on an element.")]
		public int Delay { get; set; }

		/// <summary>
		/// Tolerance, in pixels, for when selecting should start. If specified, selecting will not start until after mouse is dragged beyond distance.
		/// Reference: http://api.jqueryui.com/selectable/#option-distance
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Tolerance, in pixels, for when selecting should start. If specified, selecting will not start until after mouse is dragged beyond distance.")]
		public int Distance { get; set; }

		/// <summary>
		/// The matching child elements will be made selectees (able to be selected).
		/// Reference: http://api.jqueryui.com/selectable/#option-filter
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("*")]
		[Description("The matching child elements will be made selectees (able to be selected).")]
		public string Filter { get; set; }

		/// <summary>
		/// Possible values: 'touch', 'fit'.
		/// Reference: http://api.jqueryui.com/selectable/#option-tolerance
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("touch")]
		[Description("Possible values: 'touch', 'fit'.")]
		public string Tolerance { get; set; }

		#endregion

	}
}