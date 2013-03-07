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
using Brew.TypeConverters;

namespace Brew.Webforms.Widgets {

	/// <summary>
	/// Extend a Control with the jQuery UI Sortable behavior http://api.jqueryui.com/sortable/
	/// </summary>
	public class Sortable : Widget {

		public Sortable() : base("sortable") { }

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("create"),
				new WidgetEvent("start"),
				new WidgetEvent("sort"),
				new WidgetEvent("change"),
				new WidgetEvent("beforeStop"),
				new WidgetEvent("update"),
				new WidgetEvent("over"),
				new WidgetEvent("out"),
				new WidgetEvent("activate"),
				new WidgetEvent("deactivate"),
				new WidgetEvent("stop") { CausesPostBack = true },
				new WidgetEvent("receive") { CausesPostBack = true },
				new WidgetEvent("remove") { CausesPostBack = true }
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "appendTo", DefaultValue = "parent" }, 
				new WidgetOption { Name = "axis", DefaultValue = false }, 
				new WidgetOption { Name = "cancel", DefaultValue = ":input,button" }, 
				new WidgetOption { Name = "connectWith", DefaultValue = false }, 
				new WidgetOption { Name = "containment", DefaultValue = false }, 
				new WidgetOption { Name = "cursor", DefaultValue = "auto" }, 
				new WidgetOption { Name = "cursorAt", DefaultValue = "{}" }, 
				new WidgetOption { Name = "delay", DefaultValue = 0 }, 
				new WidgetOption { Name = "distance", DefaultValue = 1 }, 
				new WidgetOption { Name = "dropOnEmpty", DefaultValue = true }, 
				new WidgetOption { Name = "forceHelperSize", DefaultValue = false }, 
				new WidgetOption { Name = "forcePlaceholderSize", DefaultValue = false }, 
				new WidgetOption { Name = "grid", DefaultValue = null }, 
				new WidgetOption { Name = "handle", DefaultValue = false }, 
				new WidgetOption { Name = "helper", DefaultValue = "original" }, 
				new WidgetOption { Name = "items", DefaultValue = "> *" }, 
				new WidgetOption { Name = "opacity", DefaultValue = 1 }, 
				new WidgetOption { Name = "placeholder", DefaultValue = false }, 
				new WidgetOption { Name = "revert", DefaultValue = false }, 
				new WidgetOption { Name = "scroll", DefaultValue = true }, 
				new WidgetOption { Name = "scrollSensitivity", DefaultValue = 20 }, 
				new WidgetOption { Name = "scrollSpeed", DefaultValue = 20 }, 
				new WidgetOption { Name = "tolerance", DefaultValue = "intersect" }, 
				new WidgetOption { Name = "zIndex", DefaultValue = 1000 }
			};
		}

		/// <summary>
		/// This event is triggered when sorting has stopped.
		/// Reference: http://api.jqueryui.com/sortable/#event-stop
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered when sorting has stopped.")]
		public event EventHandler Stop;

		/// <summary>
		/// This event is triggered when a connected sortable list has received an item from another list.
		/// Reference: http://api.jqueryui.com/sortable/#event-receive
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered when a connected sortable list has received an item from another list.")]
		public event EventHandler Receive;

		/// <summary>
		/// This event is triggered when a sortable item has been dragged out from the list and into another.
		/// Reference: http://api.jqueryui.com/sortable/#event-remove
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered when a sortable item has been dragged out from the list and into another.")]
		public event EventHandler Remove;

		#region Widget Options

		/// <summary>
		/// Defines where the helper that moves with the mouse is being appended to during the drag (for example, to resolve overlap/zIndex issues).
		/// Reference: http://api.jqueryui.com/sortable/#option-appendTo
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("parent")]
		[Description("Defines where the helper that moves with the mouse is being appended to during the drag (for example, to resolve overlap/zIndex issues).")]
		public string AppendTo { get; set; }

		/// <summary>
		/// If defined, the items can be dragged only horizontally or vertically. Possible values:'x', 'y'.
		/// Reference: http://api.jqueryui.com/sortable/#option-axis
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If defined, the items can be dragged only horizontally or vertically. Possible values:'x', 'y'.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Axis { get; set; }

		/// <summary>
		/// Prevents sorting if you start on elements matching the selector.
		/// Reference: http://api.jqueryui.com/sortable/#option-cancel
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(":input,button")]
		[Description("Prevents sorting if you start on elements matching the selector.")]
		public string Cancel { get; set; }

		/// <summary>
		/// Takes a jQuery selector with items that also have sortables applied. If used, the sortable is now connected to the other one-way, so you can drag from this sortable to the other.
		/// Reference: http://api.jqueryui.com/sortable/#option-connectWith
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Takes a jQuery selector with items that also have sortables applied. If used, the sortable is now connected to the other one-way, so you can drag from this sortable to the other.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic ConnectWith { get; set; }

		/// <summary>
		/// Constrains dragging to within the bounds of the specified element - can be a DOM element, 'parent', 'document', 'window', or a jQuery selector.
		/// Note: the element specified for containment must have a calculated width and height (though it need not be explicit), so for example, if you have float:left sortable children and specify containment:'parent' be sure to have float:left on the sortable/parent container as well or it will have height: 0, causing undefined behavior.
		/// Reference: http://api.jqueryui.com/sortable/#option-containment
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Constrains dragging to within the bounds of the specified element - can be a DOM element, 'parent', 'document', 'window', or a jQuery selector. \nNote: the element specified for containment must have a calculated width and height (though it need not be explicit), so for example, if you have float:left sortable children and specify containment:'parent' be sure to have float:left on the sortable/parent container as well or it will have height: 0, causing undefined behavior.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Containment { get; set; }

		/// <summary>
		/// Defines the cursor that is being shown while sorting.
		/// Reference: http://api.jqueryui.com/sortable/#option-cursor
		/// </summary>
		[Category("Appearance")]
		[DefaultValue("auto")]
		[Description("Defines the cursor that is being shown while sorting.")]
		public string Cursor { get; set; }

		/// <summary>
		/// Moves the sorting element or helper so the cursor always appears to drag from the same position. Coordinates can be given as a hash using a combination of one or two keys: { top, left, right, bottom }.
		/// Reference: http://api.jqueryui.com/sortable/#option-cursorAt
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("{}")]
		[Description("Moves the sorting element or helper so the cursor always appears to drag from the same position. Coordinates can be given as a hash using a combination of one or two keys: { top, left, right, bottom }.")]
		public string CursorAt { get; set; }

		/// <summary>
		/// Time in milliseconds to define when the sorting should start. It helps preventing unwanted drags when clicking on an element.
		/// Reference: http://api.jqueryui.com/sortable/#option-delay
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Time in milliseconds to define when the sorting should start. It helps preventing unwanted drags when clicking on an element.")]
		public int Delay { get; set; }

		/// <summary>
		/// Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
		/// Reference: http://api.jqueryui.com/sortable/#option-distance
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(1)]
		[Description("Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.")]
		public int Distance { get; set; }

		/// <summary>
		/// If false items from this sortable can't be dropped to an empty linked sortable.
		/// Reference: http://api.jqueryui.com/sortable/#option-dropOnEmpty
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If false items from this sortable can't be dropped to an empty linked sortable.")]
		public bool DropOnEmpty { get; set; }

		/// <summary>
		/// If true, forces the helper to have a size.
		/// Reference: http://api.jqueryui.com/sortable/#option-forceHelperSize
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If true, forces the helper to have a size.")]
		public bool ForceHelperSize { get; set; }

		/// <summary>
		/// If true, forces the placeholder to have a size.
		/// Reference: http://api.jqueryui.com/sortable/#option-forcePlaceholderSize
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If true, forces the placeholder to have a size.")]
		public bool ForcePlaceholderSize { get; set; }

		/// <summary>
		/// Snaps the sorting element or helper to a grid, every x and y pixels. Array values: [x, y]
		/// Reference: http://api.jqueryui.com/sortable/#option-grid
		/// </summary>
		[TypeConverter(typeof(Int32ArrayConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Snaps the sorting element or helper to a grid, every x and y pixels. Array values: [x, y]")]
		public int[] Grid { get; set; }

		/// <summary>
		/// Restricts sort start click to the specified element.
		/// Reference: http://api.jqueryui.com/sortable/#option-handle
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Restricts sort start click to the specified element.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Handle { get; set; }

		/// <summary>
		/// Allows for a helper element to be used for dragging display. Possible values: 'original', 'clone'
		/// Reference: http://api.jqueryui.com/sortable/#option-helper
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("original")]
		[Description("Allows for a helper element to be used for dragging display. Possible values: 'original', 'clone'")]
		public string Helper { get; set; }

		/// <summary>
		/// Specifies which items inside the element should be sortable.
		/// Reference: http://api.jqueryui.com/sortable/#option-items
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("> *")]
		[Description("Specifies which items inside the element should be sortable.")]
		public string Items { get; set; }

		/// <summary>
		/// Defines the opacity of the helper while sorting. From 0.01 to 1
		/// Reference: http://api.jqueryui.com/sortable/#option-opacity
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(1)]
		[Description("Defines the opacity of the helper while sorting. From 0.01 to 1")]
		public float Opacity { get; set; }

		/// <summary>
		/// Class that gets applied to the otherwise white space.
		/// Reference: http://api.jqueryui.com/sortable/#option-placeholder
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Class that gets applied to the otherwise white space.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Placeholder { get; set; }

		/// <summary>
		/// If set to true, the item will be reverted to its new DOM position with a smooth animation. Optionally, it can also be set to a number that controls the duration of the animation in ms.
		/// Reference: http://api.jqueryui.com/sortable/#option-revert
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, the item will be reverted to its new DOM position with a smooth animation. Optionally, it can also be set to a number that controls the duration of the animation in ms.")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Revert { get; set; }

		/// <summary>
		/// If set to true, the page scrolls when coming to an edge.
		/// Reference: http://api.jqueryui.com/sortable/#option-scroll
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If set to true, the page scrolls when coming to an edge.")]
		public bool Scroll { get; set; }

		/// <summary>
		/// Defines how near the mouse must be to an edge to start scrolling.
		/// Reference: http://api.jqueryui.com/sortable/#option-scrollSensitivity
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(20)]
		[Description("Defines how near the mouse must be to an edge to start scrolling.")]
		public int ScrollSensitivity { get; set; }

		/// <summary>
		/// The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance.
		/// Reference: http://api.jqueryui.com/sortable/#option-scrollSpeed
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(20)]
		[Description("The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance.")]
		public int ScrollSpeed { get; set; }

		/// <summary>
		/// This is the way the reordering behaves during drag. Possible values: 'intersect', 'pointer'. In some setups, 'pointer' is more natural.
		/// Reference: http://api.jqueryui.com/sortable/#option-tolerance
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("intersect")]
		[Description("This is the way the reordering behaves during drag. Possible values: 'intersect', 'pointer'. In some setups, 'pointer' is more natural.")]
		public string Tolerance { get; set; }

		/// <summary>
		/// Z-index for element/helper while being sorted.
		/// Reference: http://api.jqueryui.com/sortable/#option-zIndex
		/// </summary>
		[Category("Layout")]
		[DefaultValue(1000)]
		[Description("Z-index for element/helper while being sorted.")]
		public int ZIndex { get; set; }

		#endregion

	}
}