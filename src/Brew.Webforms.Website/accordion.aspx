<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="accordion.aspx.cs" inherits="accordion" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">

	<h2 class="control">accordion</h2>

	<div style="width: 600px;">

		<brew:accordion runat="server">
			<accordionpanels>
				<brew:accordionpanel title="Section 1">
					<panelcontent>
						<p>
							Mauris mauris ante, blandit et, ultrices a, suscipit eget, quam. Integer
			ut neque. Vivamus nisi metus, molestie vel, gravida in, condimentum sit
			amet, nunc. Nam a nibh. Donec suscipit eros. Nam mi. Proin viverra leo ut
			odio. Curabitur malesuada. Vestibulum a velit eu ante scelerisque vulputate.
						</p>
					</panelcontent>
				</brew:accordionpanel>
				<brew:accordionpanel title="Section 2">
					<panelcontent>
						<p>
							Sed non urna. Donec et ante. Phasellus eu ligula. Vestibulum sit amet
			purus. Vivamus hendrerit, dolor at aliquet laoreet, mauris turpis porttitor
			velit, faucibus interdum tellus libero ac justo. Vivamus non quam. In
			suscipit faucibus urna.
						</p>
					</panelcontent>
				</brew:accordionpanel>
				<brew:accordionpanel title="Section 3">
					<panelcontent>
						<p>
							Nam enim risus, molestie et, porta ac, aliquam ac, risus. Quisque lobortis.
			Phasellus pellentesque purus in massa. Aenean in pede. Phasellus ac libero
			ac tellus pellentesque semper. Sed ac felis. Sed commodo, magna quis
			lacinia ornare, quam ante aliquam nisi, eu iaculis leo purus venenatis dui.
						</p>
						<ul>
							<li>List item one</li>
							<li>List item two</li>
							<li>List item three</li>
						</ul>
					</panelcontent>
				</brew:accordionpanel>
				<brew:accordionpanel title="Section 4">
					<panelcontent>
						<p>
							Cras dictum. Pellentesque habitant morbi tristique senectus et netus
			et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in
			faucibus orci luctus et ultrices posuere cubilia Curae; Aenean lacinia
			mauris vel est.
						</p>
						<p>
							Suspendisse eu nisl. Nullam ut libero. Integer dignissim consequat lectus.
			Class aptent taciti sociosqu ad litora torquent per conubia nostra, per
			inceptos himenaeos.
						</p>
					</panelcontent>
				</brew:accordionpanel>
			</accordionpanels>
		</brew:accordion>

	</div>

</asp:content>
