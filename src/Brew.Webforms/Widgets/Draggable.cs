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
	/// Extend a WebControl or HtmlControl with jQuery UI Draggable http://api.jqueryui.com/draggable
	/// </summary>
	public class Draggable : Widget, IAutoPostBackWidget {

		public Draggable() : base("draggable") { }

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("stop") { CausesPostBack = true},
				new WidgetEvent("create"),
				new WidgetEvent("start"),
				new WidgetEvent("drag")
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "addClasses", DefaultValue = true },
				new WidgetOption { Name = "appendTo", DefaultValue = "parent" },
				new WidgetOption { Name = "axis", DefaultValue = null },
				new WidgetOption { Name = "cancel", DefaultValue = ":input,option" },
				new WidgetOption { Name = "connectToSortable", DefaultValue = null },
				new WidgetOption { Name = "containment", DefaultValue = null },
				new WidgetOption { Name = "cursor", DefaultValue = "auto" },
				new WidgetOption { Name = "cursorAt", DefaultValue = null },
				new WidgetOption { Name = "delay", DefaultValue = 0 },
				new WidgetOption { Name = "distance", DefaultValue = 1 },
				new WidgetOption { Name = "grid", DefaultValue = null },
				new WidgetOption { Name = "handle", DefaultValue = null },
				new WidgetOption { Name = "helper", DefaultValue = "original" },
				new WidgetOption { Name = "iframeFix", DefaultValue = null },
				new WidgetOption { Name = "opacity", DefaultValue = null },
				new WidgetOption { Name = "refreshPositions", DefaultValue = false },
				new WidgetOption { Name = "revert", DefaultValue = null },
				new WidgetOption { Name = "revertDuration", DefaultValue = 500 },
				new WidgetOption { Name = "scope", DefaultValue = "default" },
				new WidgetOption { Name = "scroll", DefaultValue = true },
				new WidgetOption { Name = "scrollSensitivity", DefaultValue = 20 },
				new WidgetOption { Name = "scrollSpeed", DefaultValue = 20 },
				new WidgetOption { Name = "snap", DefaultValue = null },
				new WidgetOption { Name = "snapMode", DefaultValue = "both" },
				new WidgetOption { Name = "snapTolerance", DefaultValue = 20 },
				new WidgetOption { Name = "stack", DefaultValue = null },
				new WidgetOption { Name = "zIndex", DefaultValue = null }
			};
		}

		/// <summary>
		/// This event is triggered when dragging stops.
		/// Reference: http://api.jqueryui.com/draggable/#event-stop
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered when dragging stops.")]
		public event EventHandler Stop;
		
		#region .    Options    .

		/// <summary>
		/// If set to false, will prevent the ui-draggable class from being added. This may be desired as a performance optimization when calling .draggable() init on many hundreds of elements.
		/// Reference: http://api.jqueryui.com/draggable/#option-addClasses
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If set to false, will prevent the ui-draggable class from being added. This may be desired as a performance optimization when calling .draggable() init on many hundreds of elements.")]
		public bool AddClasses { get; set; }

		/// <summary>
		/// The element passed to or selected by the appendTo option will be used as the draggable helper's container during dragging. By default, the helper is appended to the same container as the draggable.
		/// Reference: http://api.jqueryui.com/draggable/#option-appendTo
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("parent")]
		[Description("The element passed to or selected by the appendTo option will be used as the draggable helper's container during dragging. By default, the helper is appended to the same container as the draggable.")]
		public string AppendTo { get; set; }

		/// <summary>
		/// Constrains dragging to either the horizontal (x) or vertical (y) axis. Possible values: 'x', 'y'.
		/// Reference: http://api.jqueryui.com/draggable/#option-axis
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Constrains dragging to either the horizontal (x) or vertical (y) axis. Possible values: 'x', 'y'.")]
		public dynamic Axis { get; set; }

		/// <summary>
		/// Prevents dragging from starting on specified elements.
		/// Reference: http://api.jqueryui.com/draggable/#option-cancel
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(":input,option")]
		[Description("Prevents dragging from starting on specified elements.")]
		public string Cancel { get; set; }

		/// <summary>
		/// Allows the draggable to be dropped onto the specified sortables. If this option is used (helper must be set to 'clone' in order to work flawlessly), a draggable can be dropped onto a sortable list and then becomes part of it.
		/// Reference: http://api.jqueryui.com/draggable/#option-connectToSortable
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Allows the draggable to be dropped onto the specified sortables. If this option is used (helper must be set to 'clone' in order to work flawlessly), a draggable can be dropped onto a sortable list and then becomes part of it.")]
		public dynamic ConnectToSortable { get; set; }

		/// <summary>
		/// Constrains dragging to within the bounds of the specified element or region. Possible string values: 'parent', 'document', 'window', [x1, y1, x2, y2].
		/// Reference: http://api.jqueryui.com/draggable/#option-containment
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Constrains dragging to within the bounds of the specified element or region. Possible string values: 'parent', 'document', 'window', [x1, y1, x2, y2].")]
		public dynamic Containment { get; set; }

		/// <summary>
		/// The css cursor during the drag operation.
		/// Reference: http://api.jqueryui.com/draggable/#option-cursor
		/// </summary>
		[Category("Appearance")]
		[DefaultValue("auto")]
		[Description("The css cursor during the drag operation.")]
		public string Cursor { get; set; }

		/// <summary>
		/// Sets the offset of the dragging helper relative to the mouse cursor. Coordinates can be given as a hash using a combination of one or two keys: { top, left, right, bottom }.
		/// Reference: http://api.jqueryui.com/draggable/#option-cursorAt
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Sets the offset of the dragging helper relative to the mouse cursor. Coordinates can be given as a hash using a combination of one or two keys: { top, left, right, bottom }.")]
		public dynamic CursorAt { get; set; }

		/// <summary>
		/// Time in milliseconds after mousedown until dragging should start. This option can be used to prevent unwanted drags when clicking on an element.
		/// Reference: http://api.jqueryui.com/draggable/#option-delay
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Time in milliseconds after mousedown until dragging should start. This option can be used to prevent unwanted drags when clicking on an element.")]
		public int Delay { get; set; }

		/// <summary>
		/// Distance in pixels after mousedown the mouse must move before dragging should start. This option can be used to prevent unwanted drags when clicking on an element.
		/// Reference: http://api.jqueryui.com/draggable/#option-distance
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(1)]
		[Description("Distance in pixels after mousedown the mouse must move before dragging should start. This option can be used to prevent unwanted drags when clicking on an element.")]
		public int Distance { get; set; }

		/// <summary>
		/// Snaps the dragging helper to a grid, every x and y pixels. Array values: [x, y]
		/// Reference: http://api.jqueryui.com/draggable/#option-grid
		/// </summary>
		[TypeConverter(typeof(Int32ArrayConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Snaps the dragging helper to a grid, every x and y pixels. Array values: [x, y]")]
		public int[] Grid { get; set; }

		/// <summary>
		/// If specified, restricts drag start click to the specified element(s).
		/// Reference: http://api.jqueryui.com/draggable/#option-handle
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("If specified, restricts drag start click to the specified element(s).")]
		public string Handle { get; set; }

		/// <summary>
		/// Allows for a helper element to be used for dragging display. Possible values: 'original', 'clone', Function. If a function is specified, it must return a DOMElement.
		/// Reference: http://api.jqueryui.com/draggable/#option-helper
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("original")]
		[Description("Allows for a helper element to be used for dragging display. Possible values: 'original', 'clone', Function. If a function is specified, it must return a DOMElement.")]
		public string Helper { get; set; }

		/// <summary>
		/// Prevent iframes from capturing the mousemove events during a drag. Useful in combination with cursorAt, or in any case, if the mouse cursor is not over the helper. If set to true, transparent overlays will be placed over all iframes on the page. If a selector is supplied, the matched iframes will have an overlay placed over them.
		/// Reference: http://api.jqueryui.com/draggable/#option-iframeFix
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Prevent iframes from capturing the mousemove events during a drag. Useful in combination with cursorAt, or in any case, if the mouse cursor is not over the helper. If set to true, transparent overlays will be placed over all iframes on the page. If a selector is supplied, the matched iframes will have an overlay placed over them.")]
		public dynamic IframeFix { get; set; }

		/// <summary>
		/// Opacity for the helper while being dragged (e.g. 0.5 results in 50% opacity while dragging).
		/// Reference: http://api.jqueryui.com/draggable/#option-opacity
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Opacity for the helper while being dragged (e.g. 0.5 results in 50% opacity while dragging).")]
		public float? Opacity { get; set; }

		/// <summary>
		/// If set to true, all droppable positions are calculated on every mousemove. Caution: This solves issues on highly dynamic pages, but dramatically decreases performance.
		/// Reference: http://api.jqueryui.com/draggable/#option-refreshPositions
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, all droppable positions are calculated on every mousemove. Caution: This solves issues on highly dynamic pages, but dramatically decreases performance.")]
		public bool RefreshPositions { get; set; }

		/// <summary>
		/// If set to true, the element will return to its start position when dragging stops. Possible string values: 'valid', 'invalid'. If set to invalid, revert will only occur if the draggable has not been dropped on a droppable. For valid, it's the other way around.
		/// Reference: http://api.jqueryui.com/draggable/#option-revert
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("If set to true, the element will return to its start position when dragging stops. Possible string values: 'valid', 'invalid'. If set to invalid, revert will only occur if the draggable has not been dropped on a droppable. For valid, it's the other way around.")]
		public dynamic Revert { get; set; }

		/// <summary>
		/// The duration of the revert animation, in milliseconds. Ignored if revert is false.
		/// Reference: http://api.jqueryui.com/draggable/#option-revertDuration
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(500)]
		[Description("The duration of the revert animation, in milliseconds. Ignored if revert is false.")]
		public int RevertDuration { get; set; }

		/// <summary>
		/// Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted by the droppable.
		/// Reference: http://api.jqueryui.com/draggable/#option-scope
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("default")]
		[Description("Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted by the droppable.")]
		public string Scope { get; set; }

		/// <summary>
		/// If set to true, container auto-scrolls while dragging.
		/// Reference: http://api.jqueryui.com/draggable/#option-scroll
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If set to true, container auto-scrolls while dragging.")]
		public bool Scroll { get; set; }

		/// <summary>
		/// Distance in pixels from the edge of the viewport after which the viewport should scroll. Distance is relative to pointer, not the draggable.
		/// Reference: http://api.jqueryui.com/draggable/#option-scrollSensitivity
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(20)]
		[Description("Distance in pixels from the edge of the viewport after which the viewport should scroll. Distance is relative to pointer, not the draggable.")]
		public int ScrollSensitivity { get; set; }

		/// <summary>
		/// The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance.
		/// Reference: http://api.jqueryui.com/draggable/#option-scrollSpeed
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(20)]
		[Description("The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance.")]
		public int ScrollSpeed { get; set; }

		/// <summary>
		/// If set to a selector or to true (equivalent to '.ui-draggable'), the draggable will snap to the edges of the selected elements when near an edge of the element.
		/// Reference: http://api.jqueryui.com/draggable/#option-snap
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("If set to a selector or to true (equivalent to '.ui-draggable'), the draggable will snap to the edges of the selected elements when near an edge of the element.")]
		public dynamic Snap { get; set; }

		/// <summary>
		/// Determines which edges of snap elements the draggable will snap to. Ignored if snap is false. Possible values: 'inner', 'outer', 'both'
		/// Reference: http://api.jqueryui.com/draggable/#option-snapMode
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("both")]
		[Description("Determines which edges of snap elements the draggable will snap to. Ignored if snap is false. Possible values: 'inner', 'outer', 'both'")]
		public string SnapMode { get; set; }

		/// <summary>
		/// The distance in pixels from the snap element edges at which snapping should occur. Ignored if snap is false.
		/// Reference: http://api.jqueryui.com/draggable/#option-snapTolerance
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(20)]
		[Description("The distance in pixels from the snap element edges at which snapping should occur. Ignored if snap is false.")]
		public int SnapTolerance { get; set; }

		/// <summary>
		/// Controls the z-Index of the set of elements that match the selector, always brings to front the dragged item. Very useful in things like window managers.
		/// Reference: http://api.jqueryui.com/draggable/#option-stack
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Controls the z-Index of the set of elements that match the selector, always brings to front the dragged item. Very useful in things like window managers.")]
		public string Stack { get; set; }

		/// <summary>
		/// CSS z-index for the helper while being dragged.
		/// Reference: http://api.jqueryui.com/draggable/#option-zIndex
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("CSS z-index for the helper while being dragged.")]
		public int? ZIndex { get; set; }

		#endregion

	}
}
