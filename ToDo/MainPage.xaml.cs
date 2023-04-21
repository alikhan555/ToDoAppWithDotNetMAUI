using ToDo.ViewModel;

namespace ToDo;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		//vm.Load().GetAwaiter().GetResult();
		BindingContext = vm;
	}
}

