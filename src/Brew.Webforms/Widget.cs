using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Brew.Webforms {

	public abstract class Widget : Control, IWidget2, IPostBackDataHandler, IPostBackEventHandler, IScriptControl {

		private Control _target = null;
		private ScriptManager _scriptManager = null;

		protected Widget(String name) {
			if (string.IsNullOrEmpty(name)) {
				throw new ArgumentException("The parameter must not be empty", "widgetName");
			}

			this.Name = name;

			//_widgetState = new WidgetState(this);

			InitDefaults();
		}

		private static void LoadHandler(object sender, EventArgs ea) {
			var page = sender as Page;
			var brew = page.FindControl("__brew");

			if (brew == null) {
				brew = new HtmlGenericControl("brew") { ID = "__brew", ClientIDMode = ClientIDMode.Static };
				brew.Controls.Add(new LiteralControl("\n"));
				page.Form.Controls.Add(brew);
			}

			if (ScriptManager.GetCurrent(page) == null) {
				page.Form.Controls.AddAt(0, new ScriptManager() { ID = "scriptmanager" });
			}
		}

		public abstract List<String> GetEvents();

		public abstract List<WidgetOption> GetOptions();

		protected override void OnInit(EventArgs e) {

			if (this.Page == null) {
				throw new InvalidOperationException("Brew Error: The page cannot be null.");
			}

			this.Page.Load -= Widget.LoadHandler;
			this.Page.Load += Widget.LoadHandler;

			base.OnInit(e);

			//WidgetState.SetWidgetNameOnTarget(this.TargetControl as IAttributeAccessor);
			//WidgetState.AddPagePreRenderCompleteHandler();
		}

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);

			this._scriptManager = ScriptManager.GetCurrent(this.Page);
			this._scriptManager.RegisterScriptControl<Widget>(this);

			if (this._target == null) {
				if (String.IsNullOrEmpty(this.For)) {
					throw new ArgumentException("Brew Error: The \"for\" attribute cannot be null or empty.");
				}
				_target = FindControl(this.For);
			}

			if (!this._target.Visible) {
				return;
			}

			Page.RegisterRequiresPostBack(this);
			//WidgetState.ParseEverything(this.TargetControl);
		}

		protected override void Render(HtmlTextWriter writer) {

			var brew = this.Page.Form.FindControl("__brew");
			var widget = new HtmlGenericControl("widget") { ClientIDMode = ClientIDMode.Static };
			var attributes = ParseOptions();

			widget.Attributes.Add("name", this.Name);
			widget.Attributes.Add("for", this.For);

			foreach (var pair in attributes) {
				var value = pair.Value;
				widget.Attributes.Add("data-" + pair.Key, Convert.ToString(value));
			}

			brew.Controls.Add(widget);
			brew.Controls.Add(new LiteralControl("\n"));

			base.Render(writer);

			this.Page.VerifyRenderingInServerForm(this);

			if (!base.DesignMode) {
				this._scriptManager.RegisterScriptDescriptors(this);
			}
		}

		private List<KeyValuePair<String, object>> ParseOptions() {
			var result = new List<KeyValuePair<String, object>>();
			var options = GetOptions();
			var type = this.GetType();

			options.Add(new WidgetOption() { Name = "disabled", DefaultValue = false });

			foreach (var option in options) {
				var property = type.GetProperties().Where(p => p.Name.ToLower() == option.Name || p.Name == option.PropertyName).FirstOrDefault();

				if (property == null) {
					throw new ArgumentException("Brew Error: Widget has option defined with no matching property.");
				}

				var value = property.GetValue(this);
				var allow = false;
				
				if (value == null && option.DefaultValue != null) {
					allow = true;
				}
				else if(value != null && !value.Equals(option.DefaultValue)){
					allow = true;
				}

				if (allow) {
					var outValue = Convert.ToString(value);

					if (value is bool) {
						outValue = outValue.ToLower();
					}
					
					var pair = new KeyValuePair<string, object>(option.Name, outValue);

					result.Add(pair);
				}
			}
			
			return result;
		}

		private void InitDefaults() {
			var options = GetOptions();
			var type = this.GetType();

			foreach (var option in options) {
				var property = type.GetProperties().Where(p => p.Name.ToLower() == option.Name || p.Name == option.PropertyName).FirstOrDefault();

				if (property == null) {
					throw new ArgumentException("Brew Error: Widget has option defined with no matching property.");
				}

				property.SetValue(this, option.DefaultValue);
			}

		}

		#region .    IWidget    .

		/// <summary>
		/// Disables (true) or enables (false) the widget.
		/// </summary>
		//[WidgetOption("disabled", false)] // every widget has a disabled option.
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Disables (true) or enables (false) the widget.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Disabled {
			get {
				return (bool)(ViewState["Disabled"] ?? false);
			}
			set {
				ViewState["Disabled"] = value;
			}
		}

		/// <summary>
		/// True, if the control should automatically postback to the server after the selected value is changed. False, otherwise.
		/// </summary>
		[DefaultValue(false)]
		[Description("True, if the control should automatically postback to the server after the selected value is changed. False, otherwise.")]
		[Category("Behavior")]
		public bool AutoPostBack {
			get {
				return (bool)(ViewState["AutoPostBack"] ?? false);
			}
			set {
				ViewState["AutoPostBack"] = value;
			}
		}

		[Browsable(false)]
		public string Name { get; private set; }

		[Browsable(false)]
		public IDictionary<string, object> Options { get; set; }

		//[Browsable(false)]
		//public Page Page { get { return base.Page; } }

		//[Browsable(false)]
		//public String ClientID { get { return this.ClientID; } }

		//[Browsable(false)]
		//public String UniqueID { get { return this.UniqueID; } }

		public String @For { get; set; }

		[Browsable(false)]
		public Control TargetControl { get { return this._target; } }

		// redundant, but we may want to do magic here.
		//public bool Visible { get { return base.Visible; } }

		public void SaveOptions() {
			//((IWidget)this).WidgetOptions = SaveOptionsAsDictionary();
		}

		#endregion

		#region .    IPostBackDataHandler    .

		bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection) {
			return LoadPostData(postDataKey, postCollection);
		}

		void IPostBackDataHandler.RaisePostDataChangedEvent() {
			RaisePostDataChangedEvent();
		}

		protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection) {
			//WidgetState.LoadPostData();
			return false;
		}

		protected virtual void RaisePostDataChangedEvent() {
			if (AutoPostBack && !Page.IsPostBackEventControlRegistered) {
				Page.AutoPostBackControl = this;
			}
		}

		#endregion

		#region .    IPostBackEventHandler    .

		void IPostBackEventHandler.RaisePostBackEvent(string eventArgument) {

		}

		#endregion

		#region .    IScriptControl    .

		IEnumerable<ScriptDescriptor> IScriptControl.GetScriptDescriptors() {
			return null;
		}

		IEnumerable<ScriptReference> IScriptControl.GetScriptReferences() {
			return BrewApplication.GetReferences();
		}

		#endregion
	}
}
