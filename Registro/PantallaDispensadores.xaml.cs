namespace Registro;

public partial class PantallaDispensadores : ContentPage
{
	public PantallaDispensadores()
	{
		InitializeComponent();
	}
    private async void Clickflecha(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PantallaPrincipal());
    }

    private void GramosSlider_ValueChanged(object sender, EventArgs e)
    {
        int gramos = (int)((Slider)sender).Value;
        GramosLabel.Text = $"Cantidad: {gramos} g";
    }

    // Maneja el clic del botón "Dispensar comida"
    private void DispensarComida_Clicked(object sender, EventArgs e)
    {
        int gramos = (int)GramosSlider.Value;
        DisplayAlert("Comida dispensada", $"Se dispensarán {gramos} gramos de comida.", "Cerrar");
    }
}