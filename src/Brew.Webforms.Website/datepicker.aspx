<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="datepicker.aspx.cs" inherits="datepicker" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<style>
		.output p { height: 20px; position: relative; }
		.output input { position: absolute; top: -4px; left: 158px; }
	</style>

	<h2 class="control">datepicker</h2>

	<p>Default: <input type="text" id="default" runat="server" /></p>
	<p>Show Other Months: <input type="text" id="othermonths" runat="server" /></p>
	<p>Show Buttons:<input type="text" id="buttonbar" runat="server" /></p>
	<p>Show Month/Year Menus: <input type="text" id="menus" runat="server" /></p>
	<p>Change the Day Labels: <input type="text" id="daynames" runat="server" /></p>
	<p>Inline: <div id="inline" runat="server"></div></p>

	<brew:datepicker runat="server" for="default"  />
	<brew:datepicker runat="server" for="othermonths" showothermonths="true" selectothermonths="true" />
	<brew:datepicker runat="server" for="buttonbar" showbuttonpanel="true" />
	<brew:datepicker runat="server" for="menus" changemonth="true" changeyear="true" />
	<brew:datepicker runat="server" for="daynames" daynamesmin="Mo,Tu,We,Th,Fr,Sa,Su" />
	<brew:datepicker runat="server" for="inline" />

</asp:content>