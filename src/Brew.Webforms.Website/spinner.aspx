<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="spinner.aspx.cs" inherits="spinner" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<script src="/scripts/globalize/globalize.js"></script>
  <script src="/scripts/globalize/globalize.culture.en-US.js"></script>
 
	<p>
		<label for="default">Select a value:</label>
		<input id="default" name="value" runat="server" />
	</p>

	<p>
		<label for="currency">Amount to donate:</label>
		<input id="currency" name="spinner" value="5" runat="server" />
	</p>

	<p>
		<label for="decimal">Decimal spinner:</label>
		<input id="decimal" name="spinner" value="5.06" runat="server" />
	</p>

	<brew:spinner runat="server" for="default" />
	<brew:spinner runat="server" for="currency" min="5" max="2500" step="25" numberFormat="C" culture="en-US" />
	<brew:spinner runat="server" for="decimal" step="0.01" numberFormat="n" />

</asp:content>

