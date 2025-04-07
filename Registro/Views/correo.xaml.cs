using Registro.ViewModels;

namespace Registro;

public partial class correo : ContentPage
{
	public correo()
	{
		InitializeComponent();
        RecuperarContraCorreo viewModel = new RecuperarContraCorreo(Navigation);
        BindingContext = viewModel;
    }
    private async void OnFlechaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }
}