namespace Registro;

public partial class VerificarCorreo : ContentPage
{
	public VerificarCorreo()
	{
		InitializeComponent();
	}
    private async void OnFlechaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new correo());
    }

    private async void pruebaARecuperarCon(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

}