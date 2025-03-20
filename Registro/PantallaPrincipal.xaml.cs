namespace Registro;

public partial class PantallaPrincipal : FlyoutPage
{
    public PantallaPrincipal()
    {
        InitializeComponent();
    }

    // Maneja el cambio de valor del Slider
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

    // Maneja el clic en las opciones del menú lateral
    private void OnMenuItemClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            // Cambia la página principal según la opción seleccionada
            if (button.Text == "Inicio")
            {
                Detail = new NavigationPage(new PantallaPrincipal());
            }
            else if (button.Text == "Cambiar contraseña")
            {
                Detail = new NavigationPage(new CambiarContraseña());
            }
            else if (button.Text == "Notificaciones")
            {
                Detail = new NavigationPage(new Notificaciones());
            }
            else if (button.Text == "Historial")
            {
                Detail = new NavigationPage(new Historial());
            }
            else if (button.Text == "Alarmas")
            {
                Detail = new NavigationPage(new Alarmas());
            }
            else if (button.Text == "Cerrar sesión")
            {
                Detail = new NavigationPage(new Login());
            }


            // Cierra el menú lateral después de seleccionar una opción
            IsPresented = false;
        }
    }

    private void AbrirMenu (object sender, EventArgs e)
    {
        this.IsPresented = true;
    }
}