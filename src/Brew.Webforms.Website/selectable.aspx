<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="selectable.aspx.cs" inherits="selectable" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<style>
		#feedback { font-size: 1.4em; }
		#content_select .ui-selecting { background: #FECA40; }
		#content_select .ui-selected { background: #F39814; color: white; }
		#content_select { list-style-type: none; margin: 0; padding: 0; width: 60%; }
		#content_select li { margin: 3px; padding: 0.4em; font-size: 1.4em; height: 18px; }
	</style>

	<ol id="select" runat="server">
		<li class="ui-widget-content">Item 1</li>
		<li class="ui-widget-content">Item 2</li>
		<li class="ui-widget-content">Item 3</li>
		<li class="ui-widget-content">Item 4</li>
		<li class="ui-widget-content">Item 5</li>
		<li class="ui-widget-content">Item 6</li>
		<li class="ui-widget-content">Item 7</li>
	</ol>

	<brew:selectable runat="server" for="select" />

</asp:content>
