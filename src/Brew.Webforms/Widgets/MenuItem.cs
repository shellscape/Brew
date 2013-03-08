using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;

using Brew;

namespace Brew.Webforms.Widgets {

	[ParseChildren(typeof(MenuItem), DefaultProperty = "Items")]
	public class MenuItem : WebControl {

		private TemplateContainer _container = null;
		private HtmlContainerControl _subMenu = null;

		public MenuItem() : base("li") {
			Items = new List<MenuItem>();
		}

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TemplateContainer(typeof(HtmlContainerControl))]
		public List<MenuItem> Items { get; private set; }

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DefaultValue((string)null)]
		[Browsable(false)]
		[TemplateContainer(typeof(TemplateContainer))]
		public virtual ITemplate Content { get; set; }

		protected override void CreateChildControls() {
			if(Content != null) {
				_container = new TemplateContainer();
				Content.InstantiateIn(_container);
				Controls.Add(_container);
			}
		}
	}
}
