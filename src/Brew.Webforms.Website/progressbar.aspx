<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="progressbar.aspx.cs" inherits="progressbar" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

<div id="progress" runat="server"></div>
<div id="indeterminate" runat="server"></div>

<brew:progressbar runat="server" for="progress" value="37" />
<brew:progressbar runat="server" for="indeterminate" value="false" />

</asp:content>
