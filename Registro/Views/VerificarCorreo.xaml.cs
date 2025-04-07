using Registro.ViewModels;
using System.Globalization;

namespace Registro;

public partial class VerificarCorreo : ContentPage
{

    public VerificarCorreo(string correo)
	{
		InitializeComponent();
        BindingContext = new VerificarCorreoViewModel(Navigation)
        {
            Correo = correo
        };
    }
    private async void OnFlechaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new correo());
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;

        if (!string.IsNullOrEmpty(e.NewTextValue) && e.NewTextValue.Length == 1)
        {
            if (entry == Entry1)
                Entry2.Focus();
            else if (entry == Entry2)
                Entry3.Focus();
            else if (entry == Entry3)
                Entry4.Focus();
            else if (entry == Entry4)
                Entry5.Focus();
            else if (entry == Entry5)
                Entry6.Focus();
            else if (entry == Entry6)
                entry.Unfocus(); // o puedes validar aquí directamente
        }
    }



}