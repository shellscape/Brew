using System;
using System.ComponentModel;

namespace Brew.Webforms {
	
	public class WidgetOption {
	
		public WidgetOption(PropertyDescriptor propertyDescriptor) {
			PropertyDescriptor = propertyDescriptor;
		}

		public WidgetOption() { }

		public String Name { get; set; }
		public String PropertyName { get; set; }
		public object DefaultValue { get; set; }
		public bool RequiresEval { get; set; }
		public bool HtmlEncoding { get; set; }

		public PropertyDescriptor PropertyDescriptor { get; set; }
	}
}