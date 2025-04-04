namespace Registro;

public partial class Alarmas : ContentPage
{
	public Alarmas()
	{
		InitializeComponent();
	}

    private async void ShowPopup(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AgregarAlarma()); // Abre la ventana emergente
    }

    private async void Alarmainicio(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PantallaPrincipal());
    }
}