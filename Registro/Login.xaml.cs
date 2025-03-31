namespace Registro;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private void OnEyeButtonClicked(object sender, EventArgs e)
    {
        // Verificamos si la contraseña es visible o no
        passwordEntry.IsPassword = !passwordEntry.IsPassword;

        // Cambiar el icono del ojo según la visibilidad de la contraseña
        if (passwordEntry.IsPassword)
        {
            eyeButton.Source = "ojocerrado.png"; // Ojo cerrado
        }
        else
        {
            eyeButton.Source = "ojoabierto.png"; // Ojo abierto
        }
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