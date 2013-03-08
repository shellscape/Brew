using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace Brew.Webforms.Widgets {

	public class ProgressBar : Widget {

		public ProgressBar() : base("progressbar") { }

		protected override HtmlTextWriterTag TagKey {
			get {
				return HtmlTextWriterTag.Div;
			}
		}

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("change"),
				new WidgetEvent("complete"),
				new WidgetEvent("create") 
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "max", DefaultValue = 100 },
				new WidgetOption { Name = "value", DefaultValue = 0 }
			};
		}

		/// <summary>
		/// The maximum value of the progressbar.
		/// Reference: http://api.jqueryui.com/progressbar/#option-max
		/// </summary>
		[Category("Data")]
		[DefaultValue(100)]
		[Description("The maximum value of the progressbar.")]
		public int Max { get; set; }

		/// <summary>
		/// The value of the progressbar.
		/// Reference: http://api.jqueryui.com/progressbar/#option-value
		/// </summary>
		[TypeConverter(typeof(Brew.TypeConverters.StringToObjectConverter))]
		[Category("Data")]
		[DefaultValue(0)]
		[Description("The value of the progressbar.")]
		public dynamic Value { get; set; }
	}
}
