<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="resizable.aspx.cs" inherits="resizable" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<div style="width: 600px;">

		<style>
			.resizable { width: 150px; height: 150px; padding: 0.5em; float: left; margin: 10px; }
			.resizable h3 { text-align: center; margin: 0; }
			.ui-resizable-helper { border: 2px dotted #00F; }
		</style>

		<div id="default" class="resizable ui-widget-content" runat="server">
			<h3 class="ui-widget-header">Resizable</h3>
		</div>

		<div id="animate" class="resizable ui-widget-content" runat="server">
			<h3 class="ui-widget-header">Animate</h3>
		</div>

		<div id="distance" class="resizable ui-widget-content" runat="server">
			<h3 class="ui-widget-header">Distance</h3>
		</div>

		<div id="helper" class="resizable ui-widget-content" runat="server">
			<h3 class="ui-widget-header">Helper</h3>
		</div>

		<div id="maxmin" class="resizable ui-widget-content" runat="server">
			<h3 class="ui-widget-header">Max / Min Size</h3>
		</div>

		<div id="preserve" class="resizable ui-widget-content" runat="server">
			<h3 class="ui-widget-header">Preserve aspect ratio</h3>
		</div>

		<div id="grid" class="resizable ui-widget-content" runat="server">
			<h3 class="ui-widget-header">Grid</h3>
		</div>

		<brew:resizable runat="server" for="default" />
		<brew:resizable runat="server" for="animate" animate="true" />
		<brew:resizable runat="server" for="distance" distance="40" />
		<brew:resizable runat="server" for="helper" helper="ui-resizable-helper" />
		<brew:resizable runat="server" for="maxmin" maxheight="250" maxwidth="350" minheight="150" minwidth="200" />
		<brew:resizable runat="server" for="preserve" aspectratio="16 / 9" />
		<brew:resizable runat="server" for="grid" grid="50" />

	</div>

</asp:content>
