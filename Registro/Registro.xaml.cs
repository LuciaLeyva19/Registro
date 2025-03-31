namespace Registro;

public partial class Registro : ContentPage
{
    public bool Contrase�aEsOculta { get; set; } = true;
    public Registro()
    {
        InitializeComponent();
        BindingContext = this;
    }
    private async void Iniciarsesion(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }

    private void ToggleContrase�aVisibilidad(object sender, EventArgs e)
    {
        Contrase�aEsOculta = !Contrase�aEsOculta;
        OnPropertyChanged(nameof(Contrase�aEsOculta)); // Notifica que la propiedad ha cambiado

        // Cambia el �cono del ojo seg�n la visibilidad de la contrase�a
        OjoIcono.Source = Contrase�aEsOculta ? "ojocerrado.png" : "ojoabierto.png";
    }


}