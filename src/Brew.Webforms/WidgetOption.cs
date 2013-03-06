using System.ComponentModel;

namespace Brew.Webforms {
	
	public class WidgetOption {
	
		public WidgetOption(PropertyDescriptor propertyDescriptor) {
			PropertyDescriptor = propertyDescriptor;
		}

		public string Name { get; set; }
		public object DefaultValue { get; set; }
		public bool RequiresEval { get; set; }
		public bool HtmlEncoding { get; set; }
		public PropertyDescriptor PropertyDescriptor { get; set; }
	}
}