using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;

using Brew;
using Brew.TypeConverters;

namespace Brew.Webforms.Widgets {

	[ControlValueProperty("Value")]
	public class Slider : Widget, IAutoPostBack {

		public Slider() : base("slider") {	}

		protected override HtmlTextWriterTag TagKey {
			get {
				return HtmlTextWriterTag.Div;
			}
		}

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("change"){ CausesPostBack = true, DataChangedEvent = true, EventName = "ValueChanged" },
				new WidgetEvent("create"),
				new WidgetEvent("start"),
				new WidgetEvent("slide"),
				new WidgetEvent("stop") 
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "animate", DefaultValue = false },
				new WidgetOption { Name = "max", DefaultValue = 100 },
				new WidgetOption { Name = "min", DefaultValue = 0 },
				new WidgetOption { Name = "orientation", DefaultValue = "horizontal" },
				new WidgetOption { Name = "range", DefaultValue = false },
				new WidgetOption { Name = "step", DefaultValue = 1 },
				new WidgetOption { Name = "value", DefaultValue = 0 },
				new WidgetOption { Name = "values", DefaultValue = null }
			};
		}

		protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection) {
			var initialValue = Value;
			base.LoadPostData(postDataKey, postCollection);
			return initialValue != Value;
		}

		protected override void RaisePostDataChangedEvent() {
			base.RaisePostDataChangedEvent();
			OnValueChanged(EventArgs.Empty);
		}

		protected virtual void OnValueChanged(EventArgs e) {
			if (ValueChanged != null) {
				ValueChanged(this, e);
			}
		}

		/// <summary>
		/// This event is triggered on slide stop, or if the value is changed programmatically (by the value method). Takes arguments event and ui. Use event.orginalEvent to detect whether the value changed by mouse, keyboard, or programmatically. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(this).slider('values', index) to get another handle's value.
		/// Reference: http://api.jqueryui.com/slider/#event-change
		/// </summary>
		[Description("This event is triggered on slide stop, or if the value is changed programmatically (by the value method). Takes arguments event and ui. Use event.orginalEvent to detect whether the value changed by mouse, keyboard, or programmatically. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(this).slider('values', index) to get another handle's value.")]
		[Category("Action")]
		public event EventHandler ValueChanged;

		#region .    Options    .

		/// <summary>
		/// Whether to slide handle smoothly when user click outside handle on the bar. Will also accept a string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
		/// Reference: http://api.jqueryui.com/slider/#option-animate
		/// </summary>
		[DefaultValue(false)]
		[Description("Whether to slide handle smoothly when user click outside handle on the bar. Will also accept a string representing one of the three predefined speeds ('slow', 'normal', or 'fast') or the number of milliseconds to run the animation (e.g. 1000).")]
		[Category("Appearance")]
		public dynamic Animate { get; set; }

		/// <summary>
		/// The maximum value of the slider.
		/// Reference: http://api.jqueryui.com/slider/#option-max
		/// </summary>
		[DefaultValue(100)]
		[Description("The maximum value of the slider.")]
		[Category("Behavior")]
		public int Max { get; set; }

		/// <summary>
		/// The minimum value of the slider.
		/// Reference: http://api.jqueryui.com/slider/#option-min
		/// </summary>
		[DefaultValue(0)]
		[Description("The minimum value of the slider.")]
		[Category("Behavior")]
		public int Min { get; set; }

		/// <summary>
		/// This option determines whether the slider has the min at the left, the max at the right or the min at the bottom, the max at the top. Possible values: 'horizontal', 'vertical'.
		/// Reference: http://api.jqueryui.com/slider/#option-orientation
		/// </summary>
		[DefaultValue("horizontal")]
		[Description("This option determines whether the slider has the min at the left, the max at the right or the min at the bottom, the max at the top. Possible values: 'horizontal', 'vertical'.")]
		[Category("Appearance")]
		public string Orientation { get; set; }

		/// <summary>
		/// If set to true, the slider will detect if you have two handles and create a stylable range element between these two. Two other possible values are 'min' and 'max'. A min range goes from the slider min to one handle. A max range goes from one handle to the slider max.
		/// Reference: http://api.jqueryui.com/slider/#option-range
		/// </summary>
		[DefaultValue(false)]
		[Description("If set to true, the slider will detect if you have two handles and create a stylable range element between these two. Two other possible values are 'min' and 'max'. A min range goes from the slider min to one handle. A max range goes from one handle to the slider max.")]
		[Category("Appearance")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Range { get; set; }

		/// <summary>
		/// Determines the size or amount of each interval or step the slider takes between min and max. The full specified value range of the slider (max - min) needs to be evenly divisible by the step.
		/// Reference: http://api.jqueryui.com/slider/#option-step
		/// </summary>
		[DefaultValue(1)]
		[Description("Determines the size or amount of each interval or step the slider takes between min and max. The full specified value range of the slider (max - min) needs to be evenly divisible by the step.")]
		[Category("Behavior")]
		public int Step { get; set; }

		/// <summary>
		/// Determines the value of the slider, if there's only one handle. If there is more than one handle, determines the value of the first handle.
		/// Reference: http://api.jqueryui.com/slider/#option-value
		/// </summary>
		[Category("Data")]
		[DefaultValue(0)]
		[Description("Determines the value of the slider, if there's only one handle. If there is more than one handle, determines the value of the first handle.")]
		public int Value { get; set; }

		/// <summary>
		/// This option can be used to specify multiple handles. If range is set to true, the length of 'values' should be 2.
		/// Reference: http://api.jqueryui.com/slider/#option-values
		/// </summary>
		[Category("Data")]
		[DefaultValue(null)]
		[TypeConverter(typeof(Int32ArrayConverter))]
		[Description("This option can be used to specify multiple handles. If range is set to true, the length of 'values' should be 2.")]
		public int[] Values { get; set; }

		#endregion

	}
}