using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brew.Webforms {

	public class WidgetEvent {

		public WidgetEvent(string name) {
			Name = name;
		}

		public String Name { get; private set; }
		public String EventName { get; set; }
		public Boolean CausesPostBack { get; set; }
		public Boolean DataChangedEvent { get; set; }
	}
}