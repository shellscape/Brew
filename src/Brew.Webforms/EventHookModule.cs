using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace Brew.Webforms {

	public class EventHookModule : IHttpModule {

		public void Init(HttpApplication context) {
			context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);
		}

		void context_PreRequestHandlerExecute(object sender, EventArgs e) {
			Page page = HttpContext.Current.CurrentHandler as Page;
			if (page != null) {
				page.PreInit += new EventHandler(page_PreInit);
			}
		}

		void page_PreInit(object sender, EventArgs e) {
			Page page = sender as Page;
			if (page == null) {
				return;
			}

			page.Load -= Widget.LoadHandler;
			page.Load += Widget.LoadHandler;

		}

		public void Dispose() {  }
	}
}
