<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="autocomplete.aspx.cs" inherits="autocomplete" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<div class="source" id="acsource">
		<h3>code behind</h3>
		<pre><code class="language-java">public partial class autocomplete : System.Web.UI.Page {
	protected void Page_Load(object sender, EventArgs e) {

		list.SourceList = new List<AutocompleteItem>() {
			new AutocompleteItem { Label = "1", Value = "2" },
			new AutocompleteItem { Label = "3", Value = "4" }
		};

	}
}</code></pre>
	</div>	

	<script>
		$(function () {
			$('#acsource').insertAfter('.source:eq(2)');
		});
	</script>

	<style>
		.output p { height: 20px; position: relative; }
		.output input { position: absolute; top: -4px; left: 200px; }
	</style>

	<h2 class="control">autocomplete</h2>

	<p>Number List, From Codebehind: <asp:textbox runat="server" id="itemlist" /></p>
	<p>Word List: <asp:textbox runat="server" id="array" /></p>
	<p>Word List, Remote Data Source: <asp:textbox runat="server" id="remote" /></p>

	<brew:autocomplete id="list" runat="server" for="itemlist" />
	<brew:autocomplete runat="server" for="array" source="ActionScript, AppleScript, Asp, BASIC, C, C++, Clojure, COBOL, ColdFusion, Erlang, Fortran, Groovy, Haskell, Java, JavaScript, Lisp, Perl, PHP, Python, Ruby, Scala, Scheme" />
	<brew:autocomplete runat="server" for="remote" sourceurl="data/remote.ashx" />
</asp:content>
