using Registro.ViewModels;

namespace Registro;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
		LoginViewModel viewModel = new LoginViewModel(Navigation);
        BindingContext = viewModel;
    }
    
}