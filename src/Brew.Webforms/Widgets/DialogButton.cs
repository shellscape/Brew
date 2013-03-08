using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Brew.Webforms.Widgets {

	public class DialogButtonList : List<DialogButton> {

		public event EventHandler Modified;

		public new void Add(DialogButton button) {
			base.Add(button);

			if (Modified != null) {
				Modified.Invoke(this, new EventArgs());
			}
		}

		public new void AddRange(IEnumerable<DialogButton> collection) {
			base.AddRange(collection);

			if (Modified != null) {
				Modified.Invoke(this, new EventArgs());
			}
		}

		public new void Remove(DialogButton button) {
			base.Remove(button);

			if (Modified != null) {
				Modified.Invoke(this, new EventArgs());
			}
		}

		public new DialogButton this[int index] { 
			get { return base[index]; }
			set {
				base[index] = value;

				if (Modified != null) {
					Modified.Invoke(this, new EventArgs());
				}
			}
		}

	}

	public class DialogButton : Control {

		public String Text { get; set; }
		public String Action { get; set; }
		public bool CloseDialog { get; set; }
	}
}
