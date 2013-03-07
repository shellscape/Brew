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
	/// Extend a TextBox with jQuery UI Autocomplete http://api.jqueryui.com/autocomplete/
	/// </summary>
	public class Autocomplete : Widget {

		private String _sourceUrl = null;
		private String[] _source = null;
		private List<AutocompleteItem> _sourceList = null;

		public Autocomplete() : base("autocomplete") { }

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("create"),
				new WidgetEvent("search"),
				new WidgetEvent("open"),
				new WidgetEvent("focus"),
				new WidgetEvent("close"),
				new WidgetEvent("response"),
				new WidgetEvent("select"),
				new WidgetEvent("change")
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "appendTo",  DefaultValue = "body" },
				new WidgetOption { Name = "autoFocus",  DefaultValue = false },
				new WidgetOption { Name = "delay",  DefaultValue = 300 },
				new WidgetOption { Name = "minLength",  DefaultValue = 1 },
				new WidgetOption { Name = "position", DefaultValue = "{}" },
				new WidgetOption { Name = "source", DefaultValue = null, PropertyName = "_Source" }
			};
		}

		/// <summary>
		/// Triggered when an item is selected from the menu; ui.item refers to the selected item. The default action of select is to replace the text field's value with the value of the selected item. Canceling this event prevents the value from being updated, but does not prevent the menu from closing.
		/// Reference: http://api.jqueryui.com/autocomplete/#event-select
		/// </summary>
		[Category("Action")]
		[Description("Triggered when an item is selected from the menu; ui.item refers to the selected item. The default action of select is to replace the text field's value with the value of the selected item. Canceling this event prevents the value from being updated, but does not prevent the menu from closing.")]
		public event EventHandler Select;

		/// <summary>
		/// Triggered when the field is blurred, if the value has changed; ui.item refers to the selected item.
		/// Reference: http://api.jqueryui.com/autocomplete/#event-change
		/// </summary>
		[Category("Action")]
		[Description("Triggered when the field is blurred, if the value has changed; ui.item refers to the selected item.")]
		public event EventHandler Change;

		#region .    Options    .

		/// <summary>
		/// Which element the menu should be appended to.
		/// Reference: http://api.jqueryui.com/autocomplete/#option-appendTo
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("body")]
		[Description("Which element the menu should be appended to.")]
		public string AppendTo { get; set; }

		/// <summary>
		/// If set to true the first item will be automatically focused.
		/// Reference: http://api.jqueryui.com/autocomplete/#option-autoFocus
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true the first item will be automatically focused.")]
		public bool AutoFocus { get; set; }

		/// <summary>
		/// The delay in milliseconds the Autocomplete waits after a keystroke to activate itself. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive.
		/// Reference: http://api.jqueryui.com/autocomplete/#option-delay
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(300)]
		[Description("The delay in milliseconds the Autocomplete waits after a keystroke to activate itself. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive.")]
		public int Delay { get; set; }

		/// <summary>
		/// The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items.
		/// Reference: http://api.jqueryui.com/autocomplete/#option-minLength
		/// </summary>
		[Category("Key")]
		[DefaultValue(1)]
		[Description("The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items.")]
		public int MinLength { get; set; }

		/// <summary>
		/// Identifies the position of the Autocomplete widget in relation to the associated input element. The "of" option defaults to the input element, but you can specify another element to position against. You can refer to the jQuery UI Position utility for more details about the various options.
		/// Reference: http://api.jqueryui.com/autocomplete/#option-position
		/// </summary>
		[TypeConverter(typeof(JsonObjectConverter))]
		[Category("Layout")]
		[DefaultValue("{}")]
		[Description("Identifies the position of the Autocomplete widget in relation to the associated input element. The \"of\" option defaults to the input element, but you can specify another element to position against. You can refer to the jQuery UI Position utility for more details about the various options.")]
		public string Position { get; set; }

		/// <summary>
		/// Defines a data source url for the data to use. Source, Source List or SourceUrl must be specified. 
		/// If SourceUrl, SourceList and Source are specified, Source or SourceList will take priority.
		/// Reference: http://api.jqueryui.com/autocomplete/#option-source
		/// </summary>
		[Category("Data")]
		[DefaultValue(null)]
		[Description("Defines a data source url for the data to use. Source, Source List or SourceUrl must be specified. If SourceUrl, SourceList and Source are specified, Source or SourceList will take priority.")]
		public String SourceUrl {
			get { return _sourceUrl; }
			set { this._sourceUrl = value; }
		}

		/// <summary>
		/// Defines the data to use. Source, Source List or SourceUrl must be specified. 
		/// Reference: http://api.jqueryui.com/autocomplete/#option-source
		/// </summary>
		[TypeConverter(typeof(Brew.TypeConverters.StringArrayConverter))]
		[Category("Data")]
		[DefaultValue(null)]
		[Description("Defines the data to use. Source, Source List or SourceUrl must be specified.")]
		public String[] Source {
			get { return this._source; }
			set { this._source = value; }
		}

		/// <summary>
		/// Defines an array of label/value pairs to use as source data. Source, Source List or SourceUrl must be specified.
		/// If both SourceList and Source are specified, Source will take priority.
		/// Reference: http://api.jqueryui.com/autocomplete/#option-source
		/// </summary>
		[TypeConverter(typeof(TypeConverters.AutocompleteListConverter))]
		[Category("Data")]
		[DefaultValue(null)]
		[Description("Defines an array of label/value pairs to use as source data. If both SourceList and Source are specified, Source will take priority.")]
		public List<AutocompleteItem> SourceList {
			get { return this._sourceList; }
			set { this._sourceList = value; }
		}

		/// <summary>
		/// Internal container for the source option.
		/// </summary>
		/// <remarks>
		/// Yes, this is ugly. It's really ugly.
		/// This is (so far) the only instance where we have to do something like this.
		/// There's no way to differentiate between a string and an array of length(1) in control attributes.
		/// If we run across this scenario again, we should write a TypeDescriptorProvider that will pull Internal/Private properties
		/// or switch back to using PropertyInfo instead of PropertyDescriptors.
		/// </remarks>
		[TypeConverter(typeof(TypeConverters.AutocompleteSourceConverter))]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public object _Source {
			get {
				if (this._source != null) {
					return this._source;
				}
				else if (this._sourceList != null) {

					// we need to perform some hackery here so that this will render properly to the widget init/options script.
					var result = new List<object>();
					foreach (AutocompleteItem item in _sourceList) {
						result.Add(new {
							label = item.Label,
							value = item.Value
						});
					}

					return result;
				}

				return this._sourceUrl;
			}
			internal set {
				//_sourceP = value;

				//if(value is String[]) {
				//  this.Source = value as String[];
				//}
				//else if(value is String) {
				//  this.SourceUrl = value as String;
				//}
				//else if(value is List<AutocompleteItem>) {
				//  this.SourceList = (List<AutocompleteItem>)value;
				//}
			}
		}

		#endregion

	}
}