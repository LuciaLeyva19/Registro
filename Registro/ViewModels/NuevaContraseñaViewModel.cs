using Registro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Registro.ViewModels
{
    public class NuevaContraseñaViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://webapi-dctw.onrender.com/api/auth/recuperar/cambiar-password";

        private string _correo;
        private string _nuevaContraseña;
        private string _confirmarContraseña;


        public string Correo
        {
            get => _correo;
            set => SetProperty(ref _correo, value);
        }

        public string NuevaContraseña
        {
            get => _nuevaContraseña;
            set => SetProperty(ref _nuevaContraseña, value);
        }

        public string ConfirmarContraseña
        {
            get => _confirmarContraseña;
            set => SetProperty(ref _confirmarContraseña, value);
        }

        //Comandoosss

        public ICommand CambiarContraseñaCommand { get; }

        //Metodoosss

        public NuevaContraseñaViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _httpClient = new HttpClient();
            CambiarContraseñaCommand = new Command(async () => await CambiarContra());

        }


        private async Task CambiarContra()
        {
            if (string.IsNullOrWhiteSpace(NuevaContraseña) || string.IsNullOrWhiteSpace(ConfirmarContraseña))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
                return;
            }

            if (NuevaContraseña != ConfirmarContraseña)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
                return;
            }

            var datos = new NuevaContraseña
            {
                correo = Correo,
                nuevaContraseña = NuevaContraseña
            };

            var json = JsonSerializer.Serialize(datos);
            var contenido = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(_apiUrl, contenido);
                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Contraseña cambiada con éxito.", "OK");
                    await _navigation.PushAsync(new Login());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo cambiar la contraseña. Intenta nuevamente.", "OK");
                }

            }

            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
    }
}
