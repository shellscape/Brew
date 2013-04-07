using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

public class XmlDoc {

	private static XmlDocument _xml = null;

	static XmlDoc() {

		using (var fs = new FileStream(HttpContext.Current.Server.MapPath("api.xml"), FileMode.Open, FileAccess.Read))
		using (var sr = new StreamReader(fs)) {
			var xml = sr.ReadToEnd();

			_xml = new XmlDocument();
			_xml.LoadXml(xml);
		}
	}

	public static String GetDescription(String section) {

		section = section.Replace(".aspx", String.Empty).Replace("brew/", String.Empty).Replace("/", String.Empty);
		
		var desc = _xml.SelectSingleNode(String.Format("/api/entries/entry[@name='{0}']/desc", section.ToLower()));
		var ldesc = _xml.SelectSingleNode(String.Format("/api/entries/entry[@name='{0}']/longdesc", section.ToLower()));
		var result = String.Empty;
		var longdesc = ldesc.InnerXml;

		if (section == "accordion") {
			result = "<p>Accordion enables you to display a set of items in a compact space, by clicking on each items header it expands or collapses it's content section.</p>";

			longdesc = longdesc.Substring(longdesc.IndexOf("<h3>Keyboard"));
		}
		else {
			result = "<p>" + desc.InnerXml + "</p>";
		}

		if (section == "datepicker") {
			longdesc = longdesc.Substring(0, longdesc.IndexOf("<h3 id=\"utility-functions\">"));
		}
		else if (section == "dialog") {
			longdesc = longdesc.Substring(0, longdesc.IndexOf("<h3>Hiding"));
		}
		else if (section == "menu") {
			longdesc = longdesc.Remove(longdesc.IndexOf("A menu can be created "), longdesc.IndexOf("<h3>Keyboard") - 3);
		}

		var depindex = longdesc.IndexOf("<h3>Dependencies");
		if (depindex > 0) {
			longdesc = longdesc.Substring(0, depindex);
		}

		result += longdesc;

		return result;
	}
}