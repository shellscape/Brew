<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="sortable.aspx.cs" inherits="sortable" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">
	<h2 class="interaction">sortable</h2>
	<style>
		ul { list-style-type: none; margin: 0; padding: 0; width: 60%; }
		ul li { margin: 0 3px 3px 3px; padding: 0.4em; padding-left: 1.5em; font-size: 1.4em; height: 18px; }
		ul li span { position: absolute; margin-left: -1.3em; }
	</style>

	<ul id="sort" runat="server">
		<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 1</li>
		<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 2</li>
		<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 3</li>
		<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 4</li>
		<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 5</li>
		<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 6</li>
		<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 7</li>
	</ul>

	<brew:sortable runat="server" for="sort" />

</asp:content>
