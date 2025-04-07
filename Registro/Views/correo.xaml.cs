namespace Registro;

public partial class correo : ContentPage
{
	public correo()
	{
		InitializeComponent();
	}
    private async void OnFlechaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }
    private async void cambiar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VerificarCorreo());
    }
}