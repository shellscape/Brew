<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="position.aspx.cs" inherits="position" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<h2 class="utility">position</h2>

	<asp:textbox runat="server" id="textbox" />

	<asp:label runat="server" id="info">Important Information</asp:label>

	<brew:position runat="server" for="info" my="top" at="bottom" of="textbox" />

</asp:content>
