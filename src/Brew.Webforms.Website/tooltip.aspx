<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="tooltip.aspx.cs" inherits="tooltip" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

<p><label for="age">Your age:</label><input id="default" title="We ask for your age only for statistical purposes." runat="server" /></p>

<p><label for="age">Your age:</label><input id="track" title="We ask for your age only for statistical purposes." runat="server" /></p>

<brew:tooltip runat="server" for="default" />
<brew:tooltip runat="server" for="track" track="true" />

</asp:content>
