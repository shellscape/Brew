using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Brew;
using Brew.TypeConverters;

namespace Brew.Webforms.Widgets {

	/// <summary>
	/// Extend a Control with the jQuery UI Resizable behavior http://api.jqueryui.com/resizable/
	/// </summary>
	public class Resizable : Widget {

		public Resizable() : base("resizable") { }

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("create"),
				new WidgetEvent("start"),
				new WidgetEvent("resize"),
				new WidgetEvent("stop"){ EventName = "Drop" }
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "alsoResize", DefaultValue = null },
				new WidgetOption { Name = "animate", DefaultValue = false },
				new WidgetOption { Name = "animateDuration", DefaultValue = "slow" },
				new WidgetOption { Name = "animateEasing", DefaultValue = "swing" },
				new WidgetOption { Name = "aspectRatio", DefaultValue = false }, 
				new WidgetOption { Name = "autoHide", DefaultValue = false },
				new WidgetOption { Name = "cancel", DefaultValue = ":input,option" },
				new WidgetOption { Name = "containment", DefaultValue = null },
				new WidgetOption { Name = "delay", DefaultValue = 0 },
				new WidgetOption { Name = "distance", DefaultValue = 1 },
				new WidgetOption { Name = "ghost", DefaultValue = false },
				new WidgetOption { Name = "grid", DefaultValue = null },
				new WidgetOption { Name = "handles", DefaultValue = "e, s, se" },
				new WidgetOption { Name = "helper", DefaultValue = null },
				new WidgetOption { Name = "maxHeight", DefaultValue = 0 },
				new WidgetOption { Name = "maxWidth", DefaultValue = 0 },
				new WidgetOption { Name = "minHeight", DefaultValue = 10 },
				new WidgetOption { Name = "minWidth", DefaultValue = 10 },
			};
		}

		/// <summary>
		/// This event is triggered at the end of a resize operation.
		/// Reference: http://api.jqueryui.com/resizable/#event-stop
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered at the end of a resize operation.")]
		public event EventHandler Drop;

		#region .    Options    .

		/// <summary>
		/// Resize these elements synchronous when resizing.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-alsoResize
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Resize these elements synchronous when resizing.")]
		public String AlsoResize { get; set; }

		/// <summary>
		/// Animates to the final size after resizing.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-animate
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Animates to the final size after resizing.")]
		public Boolean Animate { get; set; }

		/// <summary>
		/// Duration time for animating, in milliseconds. Other possible values: 'slow', 'normal', 'fast'.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-animateDuration
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("slow")]
		[Description("Duration time for animating, in milliseconds. Other possible values: 'slow', 'normal', 'fast'.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic AnimateDuration { get; set; }

		/// <summary>
		/// Easing effect for animating.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-animateEasing
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("swing")]
		[Description("Easing effect for animating.")]
		public String AnimateEasing { get; set; }

		/// <summary>
		/// If set to true, resizing is constrained by the original aspect ratio. Otherwise a custom aspect ratio can be specified, such as 9 / 16, or 0.5.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-aspectRatio
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, resizing is constrained by the original aspect ratio. Otherwise a custom aspect ratio can be specified, such as 9 / 16, or 0.5.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic AspectRatio { get; set; }

		/// <summary>
		/// If set to true, automatically hides the handles except when the mouse hovers over the element.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-autoHide
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, automatically hides the handles except when the mouse hovers over the element.")]
		public Boolean AutoHide { get; set; }

		/// <summary>
		/// Prevents resizing if you start on elements matching the selector.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-cancel
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(":input,option")]
		[Description("Prevents resizing if you start on elements matching the selector.")]
		public String Cancel { get; set; }

		/// <summary>
		/// Constrains resizing to within the bounds of the specified element. Possible values: 'parent', 'document', a DOMElement, or a Selector.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-containment
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Constrains resizing to within the bounds of the specified element. Possible values: 'parent', 'document', a DOMElement, or a Selector.")]
		public String Containment { get; set; }

		/// <summary>
		/// Tolerance, in milliseconds, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond duration. This can help prevent unintended resizing when clicking on an element.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-delay
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Tolerance, in milliseconds, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond duration. This can help prevent unintended resizing when clicking on an element.")]
		public int Delay { get; set; }

		/// <summary>
		/// Tolerance, in pixels, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond distance. This can help prevent unintended resizing when clicking on an element.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-distance
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(1)]
		[Description("Tolerance, in pixels, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond distance. This can help prevent unintended resizing when clicking on an element.")]
		public int Distance { get; set; }

		/// <summary>
		/// If set to true, a semi-transparent helper element is shown for resizing.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-ghost
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, a semi-transparent helper element is shown for resizing.")]
		public Boolean Ghost { get; set; }

		/// <summary>
		/// Snaps the resizing element to a grid, every x and y pixels. Array values: [x, y]
		/// Reference: http://api.jqueryui.com/resizable/#option-option-grid
		/// </summary>
		[TypeConverter(typeof(Int32ArrayConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Snaps the resizing element to a grid, every x and y pixels. Array values: [x, y]")]
		public int[] Grid { get; set; }

		/// <summary>
		/// If specified as a string, should be a comma-split list of any of the following: 'n, e, s, w, ne, se, sw, nw, all'. The necessary handles will be auto-generated by the plugin.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-handles
		/// </summary>
		[Category("Appearance")]
		[DefaultValue("e, s, se")]
		[Description("If specified as a string, should be a comma-split list of any of the following: 'n, e, s, w, ne, se, sw, nw, all'. The necessary handles will be auto-generated by the plugin.")]
		public String Handles { get; set; }

		/// <summary>
		/// This is the css class that will be added to a proxy element to outline the resize during the drag of the resize handle. Once the resize is complete, the original element is sized.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-helper
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("his is the css class that will be added to a proxy element to outline the resize during the drag of the resize handle. Once the resize is complete, the original element is sized.")]
		public String Helper { get; set; }

		/// <summary>
		/// This is the maximum height the resizable should be allowed to resize to.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-maxHeight
		/// </summary>
		[Category("Layout")]
		[DefaultValue(0)]
		[Description("This is the maximum height the resizable should be allowed to resize to.")]
		public int MaxHeight { get; set; }

		/// <summary>
		/// This is the maximum width the resizable should be allowed to resize to.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-maxWidth
		/// </summary>	
		[Category("Layout")]
		[DefaultValue(0)]
		[Description("This is the maximum width the resizable should be allowed to resize to.")]
		public int MaxWidth { get; set; }

		/// <summary>
		/// This is the minimum height the resizable should be allowed to resize to.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-minHeight
		/// </summary>
		[Category("Layout")]
		[DefaultValue(10)]
		[Description("This is the minimum height the resizable should be allowed to resize to.")]
		public int MinHeight { get; set; }

		/// <summary>
		/// This is the minimum width the resizable should be allowed to resize to.
		/// Reference: http://api.jqueryui.com/resizable/#option-option-minWidth
		/// </summary>
		[Category("Layout")]
		[DefaultValue(10)]
		[Description("This is the minimum width the resizable should be allowed to resize to.")]
		public int MinWidth { get; set; }

		#endregion
	}
}
