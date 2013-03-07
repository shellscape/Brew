<%@ page title="" language="C#" masterpagefile="~/Master.master" autoeventwireup="true" codefile="button.aspx.cs" inherits="button" %>
<asp:content id="content" contentplaceholderid="content" runat="Server">

<button id="butan" runat="server">A button element</button>
<input type="submit" value="A submit button" id="submit" runat="server" />
<a href="#" id="anchor" runat="server">An anchor</a>

<brew:button runat="server" for="butan" text="false" />
<brew:button runat="server" for="submit" label="new label" disabled="true" />
<brew:button runat="server" for="anchor" icons='{"primary": "ui-icon-gear", "secondary": "ui-icon-triangle-1-s"}' />

<br/><br/>

<input type="checkbox" id="check" runat="server" /><label for="content_check">Toggle</label>

<br/><br/>
 
<div id="buttonset" runat="server">
  <input type="checkbox" id="check1" /><label for="check1">B</label>
  <input type="checkbox" id="check2" /><label for="check2">I</label>
  <input type="checkbox" id="check3" /><label for="check3">U</label>
</div>

<brew:button runat="server" for="check" />
<brew:buttonset runat="server" for="buttonset" />

<br/><br/>

<div id="radio" runat="server">
  <input type="radio" id="radio1" name="radio" /><label for="radio1">Choice 1</label>
  <input type="radio" id="radio2" name="radio" checked="checked" /><label for="radio2">Choice 2</label>
  <input type="radio" id="radio3" name="radio" /><label for="radio3">Choice 3</label>
</div>

<brew:buttonset runat="server" for="radio" />

</asp:content>

