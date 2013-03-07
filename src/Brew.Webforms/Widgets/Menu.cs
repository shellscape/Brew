using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;

using Brew;
using Brew.TypeConverters;

namespace Brew.Webforms.Widgets {

	[ParseChildren(typeof(MenuItem), DefaultProperty = "Items", ChildrenAsProperties = true)]
	public class Menu : Widget, IAutoPostBack {

		public Menu() : base("menu") {
			Items = new List<MenuItem>();
		}

		public override List<WidgetEvent> GetEvents() {
			return new List<WidgetEvent>() { 
				new WidgetEvent("blur"),
				new WidgetEvent("create"),
				new WidgetEvent("focus"),
				new WidgetEvent("select")
			};
		}

		public override List<WidgetOption> GetOptions() {
			return new List<WidgetOption>() {
				new WidgetOption { Name = "icons", DefaultValue = "{ submenu: \"ui-icon-carat-1-e\" }" },
				new WidgetOption { Name = "menu", DefaultValue = "ul", PropertyName = "MenuSelector" },
				new WidgetOption { Name = "position", DefaultValue = "{ my: \"top left\", at: \"top right\" }" },
				new WidgetOption { Name = "role", DefaultValue = "menu" }
			};
		}

		protected override HtmlTextWriterTag TagKey {
			get {
				return HtmlTextWriterTag.Ul;
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
		[TemplateContainer(typeof(MenuItem))]
		public List<MenuItem> Items { get; private set; }

		#region .    Options    .

		/// <summary>
		/// Icons to use for submenus, matching an icon defined by the jQuery UI CSS Framework.
		/// Reference: http://api.jqueryui.com/menu/#option-icons
		/// </summary>
		[TypeConverter(typeof(Brew.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{ submenu: \"ui-icon-carat-1-e\" }")]
		[Description("Icons to use for submenus, matching an icon defined by the jQuery UI CSS Framework.")]
		public string Icons { get; set; }

		/// <summary>
		/// Selector for the elements that serve as the menu container, including sub-menus.
		/// Reference: http://api.jqueryui.com/menu/#option-menu
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("ul")]
		[Description("Selector for the elements that serve as the menu container, including sub-menus.")]
		public string MenuSelector { get; set; }

		/// <summary>
		/// Identifies the position of submenus in relation to the associated parent menu item. The of option defaults to the parent menu item, but you can specify another element to position against. You can refer to the jQuery UI Position utility for more details about the various options.
		/// Reference: http://api.jqueryui.com/menu/#option-position
		/// </summary>
		[TypeConverter(typeof(JsonObjectConverter))]
		[Category("Layout")]
		[DefaultValue("{ my: \"top left\", at: \"top right\" }")]
		[Description("Identifies the position of submenus in relation to the associated parent menu item. The of option defaults to the parent menu item, but you can specify another element to position against. You can refer to the jQuery UI Position utility for more details about the various options.")]
		public string Position { get; set; }

		/// <summary>
		/// Customize the ARIA roles used for the menu and menu items. The default uses "menuitem" for items. Setting the role option to "listbox" will use "option" for items. If set to null, no roles will be set, which is useful if the menu is being controlled by another element that is maintaining focus.
		/// Reference: http://api.jqueryui.com/menu/#option-menu
		/// </summary>
		[Category("Behavior")]
		[DefaultValue("menu")]
		[Description("Customize the ARIA roles used for the menu and menu items. The default uses \"menuitem\" for items. Setting the role option to \"listbox\" will use \"option\" for items. If set to null, no roles will be set, which is useful if the menu is being controlled by another element that is maintaining focus.")]
		public string Role { get; set; }

		#endregion
		
		protected override void OnPreRender(EventArgs e) {

			if(this.Items != null) {
				foreach(var item in this.Items) {
					this.Controls.Add(item);
				}
			}

			base.OnPreRender(e);
		}

		protected override void RenderContents(HtmlTextWriter writer) {
			this.RenderChildren(writer);
		}

		/// <summary>
		/// Searches the current menu for a MenuItem with the specified id parameter.
		/// </summary>
		/// <param name="id">The identifier for the MenuItem to be found.</param>
		/// <returns>The specified MenuItem, or null if the specified MenuItem does not exist.</returns>
		public Control FindItem(string id) {
			return this.Items.All().Where(c => c.ID == id).FirstOrDefault();
		}
	}
}
