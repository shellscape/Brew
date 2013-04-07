<%@ page title="" language="C#" masterpagefile="~/master.master" autoeventwireup="true" codefile="slider.aspx.cs" inherits="slider" %>

<asp:content id="content" contentplaceholderid="content" runat="Server">
	
	<style>
		.output .item { min-height: 40px; position: relative; }
		.ui-slider { position: absolute; top: -4px; left: 200px; }
		.ui-slider-horizontal { width: 400px; }
		.v { height: 120px; }
	</style>
		
	<h2 class="control">Slider</h2>

	<div class="item">
		Default Slider: <brew:slider id="slidr" runat="server" autopostback="true" />
	</div>
	
	<div class="item">
		Volume Sim: <brew:slider id="volume" runat="server" value="60" range="min" animate="true" />
	</div>

	<div class="item">
		Fixed Max Value: <brew:slider id="fixedmax" runat="server" range="max" min="1" max="10" value="2" />
	</div>

	<div class="item">
		Fixed Min Value: <brew:slider id="fixedmin" runat="server" range="min" value="37" min="1" max="700" />
	</div>

	<div class="item">
		Step in Increments: <brew:slider id="step" runat="server" value="100" min="0" max="500" step="50" />
	</div>

	<div class="item v">
		Vertical Range: <brew:slider id="verticalrange" runat="server" values="[17, 67]" orientation="vertical" range="true" />
	</div>

	<div class="item v">
		Vertical Animated: <brew:slider id="vertical" runat="server" value="60" orientation="vertical" range="min" animate="true" />
	</div>

</asp:content>
