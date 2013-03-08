using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Brew;
using Brew.TypeConverters;

namespace Brew.Webforms.Widgets {

	/// <summary>
	/// Extend a Control, WebControl or HtmlControl with the jQuery UI Dialog http://jqueryui.com/demos/dialog/
	/// </summary>
	[ParseChildren(typeof(DialogButton), DefaultProperty = "Buttons", ChildrenAsProperties = true)]
	public class Dialog : Widget {

		public Dialog() : base("dialog") {
			this.Buttons = new DialogButtonList();

			EventHandler handler = delegate(object s, EventArgs e) {
				var js = new JavaScriptSerializer();
				var dict = new Dictionary<String, String>();

				foreach (var button in this.Buttons) {
					var key = button.Text;
					String value = button.Action;

					if (String.IsNullOrEmpty(key)) {
						key = "Button " + this.Buttons.IndexOf(button);
					}

					if (button.CloseDialog) {
						value = "window.__brew && window.__brew.closedialog";
					}

					dict.Add(key, value);

					this._Buttons = js.Serialize(dict);
				}

			};

			this.Buttons.Modified += handler;
		}

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("create"),
				new WidgetEvent("beforeClose"),
				new WidgetEvent("dragStart"),
				new WidgetEvent("focus"),
				new WidgetEvent("open"),
				new WidgetEvent("drag"),
				new WidgetEvent("dragStop"),
				new WidgetEvent("resizeStart"),
				new WidgetEvent("resize"),
				new WidgetEvent("resizeStop"),
				new WidgetEvent("close")
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "autoOpen", DefaultValue = true },
				new WidgetOption { Name = "buttons", DefaultValue = "{}", PropertyName = "_Buttons" },
				new WidgetOption { Name = "closeOnEscape", DefaultValue = true },
				new WidgetOption { Name = "closeText", DefaultValue = "close" },
				new WidgetOption { Name = "dialogClass", DefaultValue = "" },
				new WidgetOption { Name = "draggable", DefaultValue = true },
				new WidgetOption { Name = "height", DefaultValue = 0 },
				new WidgetOption { Name = "hide", DefaultValue = null },
				new WidgetOption { Name = "maxHeight", DefaultValue = 0 },
				new WidgetOption { Name = "maxWidth", DefaultValue = 0 },
				new WidgetOption { Name = "minHeight", DefaultValue = 150 },
				new WidgetOption { Name = "minWidth", DefaultValue = 150 },
				new WidgetOption { Name = "modal", DefaultValue = false },		
				new WidgetOption { Name = "position", DefaultValue = "center" },
				new WidgetOption { Name = "resizable", DefaultValue = true },
				new WidgetOption { Name = "show", DefaultValue = null },
				new WidgetOption { Name = "stack", DefaultValue = true },
				new WidgetOption { Name = "title", DefaultValue = "" },
				new WidgetOption { Name = "width", DefaultValue = 300 },
				new WidgetOption { Name = "zIndex", DefaultValue = 1000 },
				new WidgetOption { Name = "trigger", DefaultValue = "" }
			};
		}

		/// <summary>
		/// This event is triggered when the dialog is closed.
		/// Reference: http://jqueryui.com/demos/dialog/#close
		/// </summary>
		[Category("Action")]
		[Description("This event is triggered when the dialog is closed.")]
		public event EventHandler Close;

		/// <summary>
		/// Specifies which buttons should be displayed on the dialog. The property key is the text of the button. The value is the callback function for when the button is clicked.  The context of the callback is the dialog element; if you need access to the button, it is available as the target of the event object.
		/// Reference: http://jqueryui.com/demos/dialog/#buttons
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TemplateContainer(typeof(DialogButton))]
		[Description("Specifies which buttons should be displayed on the dialog. The property key is the text of the button. The value is the callback function for when the button is clicked.  The context of the callback is the dialog element; if you need access to the button, it is available as the target of the event object.")]
		[Category("Appearance")]
		public DialogButtonList Buttons { get; private set; }

		/// <summary>
		/// The jQuery selector or Control ID for the element to be used as a trigger to open the dialog.
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("")]
		[Description("The jQuery selector or Control ID for the element to be used as a trigger to open the dialog.")]
		public string Trigger { get; set; }

		protected override void OnPreRender(EventArgs e) {

			if (this.Trigger != null) {
				var control = FindControl(this.Trigger);
				if (control != null) {
					this.Trigger = "#" + control.ClientID;
				}
			}			
			
			base.OnPreRender(e);
		}

		#region .    Options    .

		/// <summary>
		/// When autoOpen is true the dialog will open automatically when dialog is called. If false it will stay hidden until .dialog("open") is called on it.
		/// Reference: http://jqueryui.com/demos/dialog/#autoOpen
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("When autoOpen is true the dialog will open automatically when dialog is called. If false it will stay hidden until .dialog(\"open\") is called on it.")]
		public bool AutoOpen { get; set; }

		[TypeConverter(typeof(Brew.TypeConverters.JsonObjectConverter))]
		public string _Buttons { get; set; }

		/// <summary>
		/// Specifies whether the dialog should close when it has focus and the user presses the esacpe (ESC) key.
		/// Reference: http://jqueryui.com/demos/dialog/#closeOnEscape
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("Specifies whether the dialog should close when it has focus and the user presses the esacpe (ESC) key.")]
		public bool CloseOnEscape { get; set; }

		/// <summary>
		/// Specifies the text for the close button. Note that the close text is visibly hidden when using a standard theme.
		/// Reference: http://jqueryui.com/demos/dialog/#closeText
		/// </summary>
		[Category("Appearance")]
		[DefaultValue("close")]
		[Description("Specifies the text for the close button. Note that the close text is visibly hidden when using a standard theme.")]
		public string CloseText { get; set; }

		/// <summary>
		/// The specified class name(s) will be added to the dialog, for additional theming.
		/// Reference: http://jqueryui.com/demos/dialog/#dialogClass
		/// </summary>
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("The specified class name(s) will be added to the dialog, for additional theming.")]
		public string DialogClass { get; set; }

		/// <summary>
		/// If set to true, the dialog will be draggable will be draggable by the titlebar.
		/// Reference: http://jqueryui.com/demos/dialog/#draggable
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If set to true, the dialog will be draggable will be draggable by the titlebar.")]
		public bool Draggable { get; set; }

		/// <summary>
		/// The height of the dialog, in pixels. Specifying 'auto' is also supported to make the dialog adjust based on its content.
		/// Reference: http://jqueryui.com/demos/dialog/#height
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue("auto")]
		[Description("The height of the dialog, in pixels. Specifying 'auto' is also supported to make the dialog adjust based on its content.")]
		public dynamic Height { get; set; }

		/// <summary>
		/// The effect to be used when the dialog is closed.
		/// Reference: http://jqueryui.com/demos/dialog/#hide
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The effect to be used when the dialog is closed.")]
		public string Hide { get; set; }

		/// <summary>
		/// The maximum height to which the dialog can be resized, in pixels.
		/// Reference: http://jqueryui.com/demos/dialog/#maxHeight
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("The maximum height to which the dialog can be resized, in pixels.")]
		public dynamic MaxHeight { get; set; }

		/// <summary>
		/// The maximum width to which the dialog can be resized, in pixels.
		/// Reference: http://jqueryui.com/demos/dialog/#maxWidth
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("The maximum width to which the dialog can be resized, in pixels.")]
		public dynamic MaxWidth { get; set; }

		/// <summary>
		/// The minimum height to which the dialog can be resized, in pixels.
		/// Reference: http://jqueryui.com/demos/dialog/#minHeight
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue(150)]
		[Description("The minimum height to which the dialog can be resized, in pixels.")]
		public dynamic MinHeight { get; set; }

		/// <summary>
		/// The minimum width to which the dialog can be resized, in pixels.
		/// Reference: http://jqueryui.com/demos/dialog/#minWidth
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue(150)]
		[Description("The minimum width to which the dialog can be resized, in pixels.")]
		public dynamic MinWidth { get; set; }

		/// <summary>
		/// If set to true, the dialog will have modal behavior; other items on the page will be disabled (i.e. cannot be interacted with). Modal dialogs create an overlay below the dialog but above other page elements.
		/// Reference: http://jqueryui.com/demos/dialog/#modal
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, the dialog will have modal behavior; other items on the page will be disabled (i.e. cannot be interacted with). Modal dialogs create an overlay below the dialog but above other page elements.")]
		public bool Modal { get; set; }

		/// <summary>
		/// Specifies where the dialog should be displayed. Possible values: 1) a single string representing position within viewport: 'center', 'left', 'right', 'top', 'bottom'. 2) an array containing an x,y coordinate pair in pixel offset from left, top corner of viewport (e.g. [350,100]) 3) an array containing x,y position string values (e.g. ['right','top'] for top right corner).
		/// Reference: http://jqueryui.com/demos/dialog/#position
		/// </summary>
		[TypeConverter(typeof(JsonObjectConverter))]
		[Category("Layout")]
		[DefaultValue("center")]
		[Description("Specifies where the dialog should be displayed. Possible values: 1) a single string representing position within viewport: 'center', 'left', 'right', 'top', 'bottom'. 2) an array containing an x,y coordinate pair in pixel offset from left, top corner of viewport (e.g. [350,100]) 3) an array containing x,y position string values (e.g. ['right','top'] for top right corner).")]
		public string Position { get; set; }

		/// <summary>
		/// If set to true, the dialog will be resizeable.
		/// Reference: http://jqueryui.com/demos/dialog/#resizable
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("If set to true, the dialog will be resizeable.")]
		public bool Resizable { get; set; }

		/// <summary>
		/// The effect to be used when the dialog is opened.
		/// Reference: http://jqueryui.com/demos/dialog/#show
		/// </summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("The effect to be used when the dialog is opened.")]
		public string Show { get; set; }

		/// <summary>
		/// Specifies whether the dialog will stack on top of other dialogs. This will cause the dialog to move to the front of other dialogs when it gains focus.
		/// Reference: http://jqueryui.com/demos/dialog/#stack
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("Specifies whether the dialog will stack on top of other dialogs. This will cause the dialog to move to the front of other dialogs when it gains focus.")]
		public bool Stack { get; set; }

		/// <summary>
		/// Specifies the title of the dialog. Any valid HTML may be set as the title. The title can also be specified by the title attribute on the dialog source element.
		/// Reference: http://jqueryui.com/demos/dialog/#title
		/// </summary>
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("Specifies the title of the dialog. Any valid HTML may be set as the title. The title can also be specified by the title attribute on the dialog source element.")]
		public string Title { get; set; }

		/// <summary>
		/// The width of the dialog, in pixels.
		/// Reference: http://jqueryui.com/demos/dialog/#width
		/// </summary>
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Layout")]
		[DefaultValue(300)]
		[Description("The width of the dialog, in pixels.")]
		public dynamic Width { get; set; }

		/// <summary>
		/// The starting z-index for the dialog.
		/// Reference: http://jqueryui.com/demos/dialog/#zIndex
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(1000)]
		[Description("The starting z-index for the dialog.")]
		public int ZIndex { get; set; }

		#endregion

	}
}