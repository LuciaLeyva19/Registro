namespace Registro
{
    public partial class MainPage : ContentPage
    {
        private bool _nuevaContrasenaVisible = false;
        private bool _confirmarContrasenaVisible = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void MostrarOcultarNuevaContrasena(object sender, EventArgs e)
        {
            _nuevaContrasenaVisible = !_nuevaContrasenaVisible;
            NuevaContrasenaEntry.IsPassword = !_nuevaContrasenaVisible;
            MostrarNuevaContrasena.Source = _nuevaContrasenaVisible ? "ojoabierto.png" : "ojocerrado.png";
        }

        private void MostrarOcultarConfirmarContrasena(object sender, EventArgs e)
        {
            _confirmarContrasenaVisible = !_confirmarContrasenaVisible;
            ConfirmarContrasenaEntry.IsPassword = !_confirmarContrasenaVisible;
            MostrarConfirmarContrasena.Source = _confirmarContrasenaVisible ? "ojoabierto.png" : "ojocerrado.png";
        }

        private async void regreso(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new correo());  
        }
    }
}
