namespace Registro;

public partial class Registro : ContentPage
{
    public Registro()
    {
        InitializeComponent();
    }
    private async void Iniciarsesion(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }
}