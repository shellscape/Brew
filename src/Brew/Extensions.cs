using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.UI;

namespace Brew {

	public static class Extensions {

		/// <summary>
		/// Compares two enumberable collections to determine if their contained values are equal.
		/// </summary>
		public static bool ItemsAreEqual<T>(this IEnumerable<T> source, IEnumerable<T> second) {
			return source.SequenceEqual(second);
		}

		/// <summary>
		/// Allows Linq operations on the controls collection.
		/// </summary>
		public static IEnumerable<Control> All(this ControlCollection controls) {
			foreach (Control control in controls) {
				foreach (Control grandChild in control.Controls.All())
					yield return grandChild;

				yield return control;
			}
		}
	}
}