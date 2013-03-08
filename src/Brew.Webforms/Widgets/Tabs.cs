using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using Brew;
using Brew.TypeConverters;

namespace Brew.Webforms.Widgets {

	[ParseChildren(typeof(TabPage), DefaultProperty = "TabPages", ChildrenAsProperties = true)]
	public class Tabs : Widget, IAutoPostBack {

		private List<TabPage> _tabPages;

		public Tabs() : base("tabs") {
			_tabPages = new List<TabPage>();
		}

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("beforeLoad"),
				new WidgetEvent("create"),
				new WidgetEvent("beforeActivate"),
				new WidgetEvent("load"),
				new WidgetEvent("activate") { CausesPostBack = true, EventName = "ActiveTabChanged" }
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "collapsible", DefaultValue = false },
				new WidgetOption { Name = "disabled", DefaultValue = false },
				new WidgetOption { Name = "event", DefaultValue = "click" },
				new WidgetOption { Name = "heightStyle", DefaultValue = "{}" },
				new WidgetOption { Name = "hide", DefaultValue = null },
				new WidgetOption { Name = "show", DefaultValue = null },
				new WidgetOption { Name = "active", DefaultValue = 0 }
			};
		}

		protected override HtmlTextWriterTag TagKey {
			get {
				return HtmlTextWriterTag.Div;
			}
		}

		public override ControlCollection Controls {
			get {
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TemplateContainer(typeof(TabPage))]
		public List<TabPage> TabPages { get { return this._tabPages; } }

		/// <summary>
		/// This event is triggered when clicking a tab.
		/// Reference: http://api.jqueryui.com/tabs/#event-select
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered when clicking a tab.")]
		public event EventHandler ActiveTabChanged;

		#region .    Options    .

		/// <summary>
		/// Set to true to allow an already selected tab to become unselected again upon reselection.
		/// Reference: http://api.jqueryui.com/tabs/#option-collapsible
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Set to true to allow an already selected tab to become unselected again upon reselection.")]
		public bool Collapsible { get; set; }

		/// <summary>
		/// Disables (true) or enables (false) the widget.
		/// - OR -
		/// An array containing the position of the tabs (zero-based index) that should be disabled on initialization.
		/// Reference: http://api.jqueryui.com/tabs/#option-disabled
		/// </summary>
		/*
		 * This is really a one-time case specifically for the tabs widget. No other jQuery UI widgets double up on the disabled option.
		 */
		[TypeConverter(typeof(BooleanInt32ArrayConverter))]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Disables (true) or enables (false) the widget. - OR - An array containing the position of the tabs (zero-based index) that should be disabled on initialization.")]
		public new dynamic Disabled { get; set; }

		/// <summary>
		/// The type of event to be used for selecting a tab.
		/// Reference: http://api.jqueryui.com/tabs/#option-event
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("click")]
		[Description("The type of event to be used for selecting a tab.")]
		public string Event { get; set; }

		/// <summary>
		/// Controls the height of the accordion and each panel. Possible values: 
		/// "auto": All panels will be set to the height of the tallest panel. 
		/// "fill": Expand to the available height based on the accordion's parent height. 
		/// "content": Each panel will be only as tall as its content.
		/// Reference: http://api.jqueryui.com/tabs/#option-heightstyle
		/// </summary>
		[TypeConverter(typeof(Brew.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{}")]
		[Description(@"Controls the height of the tabs and each panel. Possible values: 
""auto"": All panels will be set to the height of the tallest panel. 
""fill"": Expand to the available height based on the tabs' parent height. 
""content"": Each panel will be only as tall as its content.")]
		public string HeightStyle { get; set; }

		/// <summary>
		/// Specifies if and how to animate the hiding of the panel.
		/// Reference: http://api.jqueryui.com/tabs/#option-hide
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Specifies if and how to animate the hiding of the panel.")]
		public dynamic Hide { get; set; }

		/// <summary>
		/// Specifies if and how to animate the showing of the panel.
		/// Reference: http://api.jqueryui.com/tabs/#option-hide
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Specifies if and how to animate the showing of the panel.")]
		public dynamic Show { get; set; }

		/// <summary>
		/// Zero-based index of the tab to be selected on initialization. To set all tabs to unselected pass -1 as value.
		/// Reference: http://api.jqueryui.com/tabs/#option-selected
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Zero-based index of the tab to be selected on initialization. To set all tabs to unselected pass -1 as value.")]
		public int Active { get; set; }
		
		#endregion
	
		protected override void OnPreRender(EventArgs e) {

			this.Controls.Clear();

			if(TabPages != null) {
				foreach(TabPage page in TabPages) {
					this.Controls.Add(page);
				}
			}

			base.OnPreRender(e);
		}

		protected override void RenderChildren(HtmlTextWriter writer) {

			writer.WriteBeginTag("ul");

			writer.Write(HtmlTextWriter.TagRightChar);

			if(TabPages != null) {
				foreach(TabPage page in TabPages) {
					writer.WriteFullBeginTag("li");

					writer.WriteBeginTag("a");
					writer.WriteAttribute("href", "#" + page.ClientID);
					writer.Write(HtmlTextWriter.TagRightChar);
					writer.Write(page.Title);
					writer.WriteEndTag("a");

					writer.WriteEndTag("li");
				}
			}

			writer.WriteEndTag("ul");

			base.RenderChildren(writer);
		}
	}
}
