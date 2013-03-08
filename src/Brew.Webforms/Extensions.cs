using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Brew.Webforms.Widgets;

namespace Brew.Webforms {
	public static class Extensions {

		public static PropertyInfo GetProperty(this Type type, WidgetOption option) {
			var list = type.GetProperties();
			PropertyInfo result = null;

			if (!String.IsNullOrEmpty(option.PropertyName)) {
				result = list.Where(p => p.Name == option.PropertyName).FirstOrDefault();
			}

			if (result == null) {
				result = list.Where(p => p.Name.ToLower() == option.Name.ToLower()).FirstOrDefault();
			}

			return result;
		}

		/// <summary>
		/// Allows Linq operations on the controls collection.
		/// </summary>
		internal static IEnumerable<MenuItem> All(this List<MenuItem> items) {
			foreach (MenuItem item in items) {
				foreach (MenuItem grandChild in item.Items.All())
					yield return grandChild;

				yield return item;
			}
		}

	}
}
