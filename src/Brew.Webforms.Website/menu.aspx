<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="menu.aspx.cs" inherits="menu" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<style>
		.ui-menu { width: 150px; }
		.output > div { width: 600px; }
  </style>

	<h2 class="control">menu</h2>

	<div>

		<brew:menu runat="server">
			<brew:menuitem cssclass="ui-state-disabled"><a href="#">Aberdeen</a></brew:menuitem>
			<brew:menuitem><a href="#">Ada</a></brew:menuitem>
			<brew:menuitem><a href="#">Adamsville</a></brew:menuitem>
			<brew:menuitem><a href="#">Addyston</a></brew:menuitem>
			<brew:menuitem>
				<a href="#">Delphi</a>
				<brew:menu runat="server">
					<brew:menuitem runat="server" cssclass="ui-state-disabled"><a href="#">Ada</a></brew:menuitem>
					<brew:menuitem runat="server"><a href="#">Saarland</a></brew:menuitem>
					<brew:menuitem runat="server"><a href="#">Salzburg</a></brew:menuitem>
				</brew:menu>
			</brew:menuitem>
			<brew:menuitem><a href="#">Saarland</a></brew:menuitem>
			<brew:menuitem>
				<a href="#">Salzburg</a>
				<brew:menu runat="server">

					<brew:menuitem>
						<a href="#">Delphi</a>
						<brew:menu runat="server">
							<brew:menuitem runat="server"><a href="#">Ada</a></brew:menuitem>
							<brew:menuitem runat="server"><a href="#">Saarland</a></brew:menuitem>
							<brew:menuitem runat="server"><a href="#">Salzburg</a></brew:menuitem>
						</brew:menu>
						<brew:menuitem><a href="#">Perch</a></brew:menuitem>
					</brew:menuitem>


				</brew:menu>

			</brew:menuitem>

		</brew:menu>

	</div>

</asp:content>
