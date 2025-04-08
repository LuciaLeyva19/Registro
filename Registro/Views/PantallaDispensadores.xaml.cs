using Registro.ViewModels;

namespace Registro;

public partial class PantallaDispensadores : ContentPage
{
	public PantallaDispensadores()
	{
		InitializeComponent();
        PantallaDispensadoresViewModel viewModel = new PantallaDispensadoresViewModel();
        BindingContext = viewModel;
    }
    private async void Clickflecha(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PantallaPrincipal());
    }

   
}