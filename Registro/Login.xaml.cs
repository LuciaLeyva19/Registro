namespace Registro;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

	private async void RecuperarContra (object sender, EventArgs e)
	{
		await Navigation.PushAsync(new correo());
	}

    private void PantallaPrincipal_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PantallaPrincipal());
    }

    private void Registro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Registro());
    }
}