using ToDo.ViewModel;

namespace ToDo;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}