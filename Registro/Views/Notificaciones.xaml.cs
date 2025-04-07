namespace Registro;

public partial class Notificaciones : ContentPage
{
	public Notificaciones()
	{
		InitializeComponent();
	}

    private async void notifinicio(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PantallaPrincipal());
    }

}