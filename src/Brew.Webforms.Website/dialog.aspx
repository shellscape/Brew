<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="dialog.aspx.cs" inherits="dialog" %>


<asp:content id="content" contentplaceholderid="content" runat="Server">
	
	<div id="basic" title="Basic dialog" runat="server">
		<p>This is the default dialog which is useful for displaying information. The dialog window can be moved, resized and closed with the 'x' icon.</p>
	</div>

	<div id="animated" title="Basic dialog" runat="server">
		<p>This is an animated dialog which is useful for displaying information. The dialog window can be moved, resized and closed with the 'x' icon.</p>
	</div>

	<div id="confirm" title="Empty the recycle bin?" runat="server">
		<p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>These items will be permanently deleted and cannot be recovered. Are you sure?</p>
	</div>

	<button id="basic-trigger" type="button">open basic dialog</button>
	<button id="animatedtrigger" runat="server" type="button">open animated dialog</button>
	<button id="confirm-trigger" type="button">open confirm dialog</button>

	<brew:dialog runat="server" for="basic" trigger="#basic-trigger" />
	<brew:dialog runat="server" for="animated" autoopen="false" trigger="animatedtrigger" show='{ effect: "blind", duration: 1000 }' hide='{ effect: "explode", duration: 1000 }' />
	<brew:dialog runat="server" for="confirm" autoopen="false" trigger="#confirm-trigger">
		<brew:dialogbutton text="Delete all items" closedialog="true" />
		<brew:dialogbutton text="Cancel" closedialog="true" />
	</brew:dialog>

</asp:content>
