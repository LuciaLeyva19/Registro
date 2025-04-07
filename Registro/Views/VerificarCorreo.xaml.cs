using Registro.ViewModels;
using System.Globalization;

namespace Registro;

public partial class VerificarCorreo : ContentPage
{

    public VerificarCorreo(string correo)
	{
		InitializeComponent();
        BindingContext = new VerificarCorreoViewModel(Navigation)
        {
            Correo = correo
        };
    }
    private async void OnFlechaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new correo());
    }

   

}