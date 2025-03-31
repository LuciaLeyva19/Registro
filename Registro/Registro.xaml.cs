namespace Registro;

public partial class Registro : ContentPage
{
    public bool ContraseñaEsOculta { get; set; } = true;
    public Registro()
    {
        InitializeComponent();
        BindingContext = this;
    }
    private async void Iniciarsesion(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }

    private void ToggleContraseñaVisibilidad(object sender, EventArgs e)
    {
        ContraseñaEsOculta = !ContraseñaEsOculta;
        OnPropertyChanged(nameof(ContraseñaEsOculta)); // Notifica que la propiedad ha cambiado

        // Cambia el ícono del ojo según la visibilidad de la contraseña
        OjoIcono.Source = ContraseñaEsOculta ? "ojocerrado.png" : "ojoabierto.png";
    }


}