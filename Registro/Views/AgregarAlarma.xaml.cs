namespace Registro;

public partial class AgregarAlarma : ContentPage
{
	public AgregarAlarma()
	{
		InitializeComponent();
	}

    private async void ClosePopup(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(); // Cierra la ventana emergente
    }
}