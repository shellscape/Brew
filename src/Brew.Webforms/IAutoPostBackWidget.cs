
namespace Brew.Webforms {

	interface IAutoPostBackWidget : IWidget {
		new bool AutoPostBack { get; }
	}

	interface IAutoPostBack {
		bool AutoPostBack { get; }
	}
}