<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="autocomplete.aspx.cs" inherits="autocomplete" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<h2 class="control">autocomplete</h2>

	<asp:textbox runat="server" id="itemlist" />
	<asp:textbox runat="server" id="array" />
	<asp:textbox runat="server" id="remote" />

	<brew:autocomplete id="list" runat="server" for="itemlist" />
	<brew:autocomplete runat="server" for="array" source="ActionScript, AppleScript, Asp, BASIC, C, C++, Clojure, COBOL, ColdFusion, Erlang, Fortran, Groovy, Haskell, Java, JavaScript, Lisp, Perl, PHP, Python, Ruby, Scala, Scheme" />
	<brew:autocomplete runat="server" for="remote" sourceurl="data/remote.ashx" />
</asp:content>
