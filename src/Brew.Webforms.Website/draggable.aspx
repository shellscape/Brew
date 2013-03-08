<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="draggable.aspx.cs" inherits="draggable" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<style>
		.ui-widget-content { width: 100px; height: 100px; padding: 0.5em; float: left; margin: 0 10px 10px 0; }
	</style>

	<div id="default" class="ui-widget-content" runat="server">
		<p>Drag me around</p>
	</div>

	<div id="axis" class="draggable ui-widget-content" runat="server">
		<p>I can be dragged only vertically</p>
	</div>

	<div id="cursor" class="ui-widget-content" runat="server">
		<p>My cursor position is only controlled for the 'bottom' value</p>
	</div>

	<div id="delay" class="ui-widget-content" runat="server">
		<p>Only if you drag me by 20 pixels, the dragging will start</p>
	</div>

	<div id="handle" class="ui-widget-content" runat="server">
		<p>You can drag me around…</p>
		<p class="ui-widget-header">…but you can't drag me by this handle.</p>
	</div>

	<div id="revert" class="ui-widget-content" runat="server">
		<p>Revert the original</p>
	</div>

	<div id="helper" class="ui-widget-content" runat="server">
		<p>Revert the helper</p>
	</div>

	<brew:draggable runat="server" for="default" />
	<brew:draggable runat="server" for="axis" axis="y" />
	<brew:draggable runat="server" for="cursor" cursor="crosshair" cursorat="{ bottom: 0 }" />
	<brew:draggable runat="server" for="delay" distance="20" />
	<brew:draggable runat="server" for="handle" cancel="p.ui-widget-header" />
	<brew:draggable runat="server" for="revert" revert="true" />
	<brew:draggable runat="server" for="helper" revert="true" helper="clone" />

</asp:content>
