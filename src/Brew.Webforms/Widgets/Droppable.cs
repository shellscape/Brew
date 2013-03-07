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
	/// Extend a WebControl or HtmlControl with jQuery UI Droppable http://api.jqueryui.com/droppable
	/// </summary>
	public class Droppable : Widget, IAutoPostBackWidget {

		public Droppable() : base("droppable") { }

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("drop") { CausesPostBack = true },
				new WidgetEvent("create"),
				new WidgetEvent("activate"),
				new WidgetEvent("deactivate"),
				new WidgetEvent("over"),
				new WidgetEvent("out")
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "accept", DefaultValue = "*" },
				new WidgetOption { Name = "activeClass", DefaultValue = false },
				new WidgetOption { Name = "addClasses", DefaultValue = true },
				new WidgetOption { Name = "greedy", DefaultValue = false },
				new WidgetOption { Name = "hoverClass", DefaultValue = false },
				new WidgetOption { Name = "scope", DefaultValue = "default" },
				new WidgetOption { Name = "tolerance", DefaultValue = "intersect" }
			};
		}

		/// <summary>
		/// This event is triggered when an accepted draggable is dropped 'over' (within the tolerance of) this droppable. In the callback, $(this) represents the droppable the draggable is dropped on.
		/// ui.draggable represents the draggable.
		/// Reference: http://api.jqueryui.com/droppable/#event-drop
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered when an accepted draggable is dropped 'over' (within the tolerance of) this droppable. In the callback, $(this) represents the droppable the draggable is dropped on.")]
		public event EventHandler Drop;

    #region .    Options    .

    /// <summary>
    /// All draggables that match the selector will be accepted. If a function is specified, the function will be called for each draggable on the page (passed as the first argument to the function), to provide a custom filter. The function should return true if the draggable should be accepted.
    /// Reference: http://api.jqueryui.com/droppable/#option-accept
    /// </summary>
		[Category("Behavior")]
		[DefaultValue("*")]
		[Description("All draggables that match the selector will be accepted. If a function is specified, the function will be called for each draggable on the page (passed as the first argument to the function), to provide a custom filter. The function should return true if the draggable should be accepted.")]
    public string Accept { get; set; }

    /// <summary>
    /// If specified, the class will be added to the droppable while an acceptable draggable is being dragged.
    /// Reference: http://api.jqueryui.com/droppable/#option-activeClass
    /// </summary>
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("If specified, the class will be added to the droppable while an acceptable draggable is being dragged.")]
		[TypeConverter(typeof(StringToObjectConverter))]
    public dynamic ActiveClass { get; set; }

    /// <summary>
    /// If set to false, will prevent the ui-droppable class from being added. This may be desired as a performance optimization when calling .droppable() init on many hundreds of elements.
    /// Reference: http://api.jqueryui.com/droppable/#option-addClasses
    /// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If set to false, will prevent the ui-droppable class from being added. This may be desired as a performance optimization when calling .droppable() init on many hundreds of elements.")]
    public bool AddClasses { get; set; }

    /// <summary>
    /// If true, will prevent event propagation on nested droppables.
    /// Reference: http://api.jqueryui.com/droppable/#option-greedy
    /// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If true, will prevent event propagation on nested droppables.")]
    public bool Greedy { get; set; }

    /// <summary>
    /// If specified, the class will be added to the droppable while an acceptable draggable is being hovered.
    /// Reference: http://api.jqueryui.com/droppable/#option-hoverClass
    /// </summary>
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("If specified, the class will be added to the droppable while an acceptable draggable is being hovered.")]
		[TypeConverter(typeof(StringToObjectConverter))]
    public dynamic HoverClass { get; set; }

    /// <summary>
    /// Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted.
    /// Reference: http://api.jqueryui.com/droppable/#option-scope
    /// </summary>
		[Category("Behavior")]
		[DefaultValue("default")]
		[Description("Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted.")]
    public string Scope { get; set; }

    /// <summary>
    /// Specifies which mode to use for testing whether a draggable is 'over' a droppable. Possible values: 'fit', 'intersect', 'pointer', 'touch'.
    /// Reference: http://api.jqueryui.com/droppable/#option-tolerance
    /// </summary>
		[Category("Behavior")]
		[DefaultValue("intersect")]
		[Description("Specifies which mode to use for testing whether a draggable is 'over' a droppable. Possible values: 'fit', 'intersect', 'pointer', 'touch'.")]
    public string Tolerance { get; set; }

    #endregion

	}
}