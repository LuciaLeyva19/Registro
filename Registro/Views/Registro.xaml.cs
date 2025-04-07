using Registro.ViewModels;

namespace Registro;

public partial class Registro : ContentPage
{
    public bool ContraseñaEsOculta { get; set; } = true;
    public Registro()
    {
        InitializeComponent();
        RegistrarViewModel viewModel = new RegistrarViewModel(Navigation);
        BindingContext = viewModel;
    }
    private async void Iniciarsesion(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }

    


}