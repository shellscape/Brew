<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="droppable.aspx.cs" inherits="droppable" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">
	<h2 class="interaction">droppable</h2>
	<style>
		#content_drag { width: 100px; height: 100px; padding: 0.5em; float: left; margin: 10px 10px 10px 0; }
		#content_drop { width: 150px; height: 150px; padding: 0.5em; float: left; margin: 10px; }
	</style>

	<div id="drag" class="ui-widget-content" runat="server">
		<p>Drag me to my target</p>
	</div>

	<div id="drop" class="ui-widget-header" runat="server">
		<p>Drop here</p>
	</div>

	<brew:draggable runat="server" for="drag" />
	<brew:droppable runat="server" for="drop" accept="#content_drag" activeClass="ui-state-hover" hoverClass="ui-state-active" />

</asp:content>
