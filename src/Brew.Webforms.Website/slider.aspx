<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="slider.aspx.cs" inherits="slider" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<brew:slider id="slidr" runat="server" autopostback="true" />
	<brew:slider id="volume" runat="server" value="60" range="min" animate="true" />
	<brew:slider id="vertical" runat="server" value="60" orientation="vertical" range="min" animate="true" />
	<brew:slider id="fixedmax" runat="server" range="max" min="1" max="10" value="2" />
	<brew:slider id="fixedmin" runat="server" range="min" value="37" min="1" max="700" />
	<brew:slider id="step" runat="server" value="100" min="0" max="500" step="50" />
	<brew:slider id="verticalrange" runat="server" values="[17, 67]" orientation="vertical" range="true" />
</asp:content>
