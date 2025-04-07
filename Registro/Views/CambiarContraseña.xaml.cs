namespace Registro;
using Microsoft.Maui.Controls;

public partial class CambiarContraseña : ContentPage
{
   
    public bool NuevaContrasenaEsOculta { get; set; } = true; 
    public bool ConfirmarContrasenaEsOculta { get; set; } = true; 

    public CambiarContraseña()
    {
        InitializeComponent();
        BindingContext = this; 
    }

 
    private void ToggleNuevaContrasena(object sender, EventArgs e)
    {
        NuevaContrasenaEsOculta = !NuevaContrasenaEsOculta;
        OnPropertyChanged(nameof(NuevaContrasenaEsOculta));
    }

    // Método para alternar la visibilidad de la contraseña confirmada
    private void ToggleConfirmarContrasena(object sender, EventArgs e)
    {
        ConfirmarContrasenaEsOculta = !ConfirmarContrasenaEsOculta;
        OnPropertyChanged(nameof(ConfirmarContrasenaEsOculta)); 
    }

    private async void cambiarConainicio(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PantallaPrincipal());
    }


   
}