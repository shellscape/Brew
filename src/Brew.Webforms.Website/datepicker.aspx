<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="datepicker.aspx.cs" inherits="datepicker" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<h2 class="control">datepicker</h2>

	<p>Date: <input type="text" id="default" runat="server" /></p>
	<p>Date: <input type="text" id="othermonths" runat="server" /></p>
	<p>Date: <input type="text" id="buttonbar" runat="server" /></p>
	<p>Date: <input type="text" id="menus" runat="server" /></p>
	<p>Date: <input type="text" id="daynames" runat="server" /></p>

	<brew:datepicker runat="server" for="default" />
	<brew:datepicker runat="server" for="othermonths" showothermonths="true" selectothermonths="true" />
	<brew:datepicker runat="server" for="buttonbar" showbuttonpanel="true" />
	<brew:datepicker runat="server" for="menus" changemonth="true" changeyear="true" />
	<brew:datepicker runat="server" for="daynames" daynamesmin="Mo,Tu,We,Th,Fr,Sa,Su" />

</asp:content>