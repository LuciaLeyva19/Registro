using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registro.Service;
using Registro.Models;
using Registro.ViewModels;
using System.Windows.Input;
using System.Globalization;
using System.Text.Json;
using System.Diagnostics;

namespace Registro.ViewModels
{
    public class RecuperarContraCorreo : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        private readonly INavigation _navigation;

        private const string ApiURL = "https://webapi-dctw.onrender.com/api/auth/recuperar/enviar-codigo";
        private string _correo;

        public string Correo
        {
            get => _correo;
            set => SetProperty(ref _correo, value);
        }

        //Comandoooosss

        public ICommand EnviarCodigoCommand { get; }

        public RecuperarContraCorreo(INavigation navigation)
        {
            _navigation = navigation;
            _httpClient = new HttpClient();
            EnviarCodigoCommand = new Command(async () => await EnviarCodigo());
        }

        public async Task EnviarCodigo()
        {
            if (string.IsNullOrWhiteSpace(_correo))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor ingresa tu correo electrónico.", "OK");
                return;
            }

            var modelo = new RecuperarContraEmail
            {
                correo = Correo
            };
            var json = JsonSerializer.Serialize(modelo);
            var contenido = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(ApiURL, contenido);

                if (response.IsSuccessStatusCode)
                {
                    // Aquí puedes manejar la respuesta exitosa
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Código enviado al correo electrónico.", "OK");
                    // Navegar a la siguiente página
                    await _navigation.PushAsync(new VerificarCorreo(Correo));
                }
                else
                {
                    // Aquí puedes manejar el error
                    var errorContent = await response.Content.ReadAsStringAsync();
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo enviar el código. Intenta nuevamente.", "OK");
                }


            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Ocurrió un error al enviar el código. Intenta nuevamente.", "OK");
            }

        }
    }
}
