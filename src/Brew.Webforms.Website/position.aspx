<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="position.aspx.cs" inherits="position" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<asp:textbox runat="server" id="textbox" />

	<asp:label runat="server" id="info">Important Information</asp:label>

	<brew:position runat="server" for="info" my="left" at="right" of="textbox" />

</asp:content>
