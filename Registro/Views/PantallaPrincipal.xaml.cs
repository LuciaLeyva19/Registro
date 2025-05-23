using Registro.ViewModels;

namespace Registro;

public partial class PantallaPrincipal : FlyoutPage
{
    public PantallaPrincipal()
    {
        InitializeComponent();
        BindingContext = new PantallaPrincipalViewModel();
    }

    // Maneja el cambio de valor del Slider
   
    // Maneja el clic en las opciones del men� lateral
    private void OnMenuItemClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            // Cambia la p�gina principal seg�n la opci�n seleccionada
            if (button.Text == "Inicio")
            {
                Detail = new NavigationPage(new PantallaPrincipal());
            }
            else if (button.Text == "Cambiar contrase�a")
            {
                Detail = new NavigationPage(new CambiarContrase�a());
            }

            else if (button.Text == "Alarmas")
            {
                Detail = new NavigationPage(new Alarmas());
            }
            else if (button.Text == "Cerrar sesi�n")
            {
                Detail = new NavigationPage(new Login());
            }


            // Cierra el men� lateral despu�s de seleccionar una opci�n
            IsPresented = false;
        }
    }

    private void AbrirMenu (object sender, EventArgs e)
    {
        this.IsPresented = true;
    }
    private async void OnFrameTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PantallaDispensadores());
    }
}