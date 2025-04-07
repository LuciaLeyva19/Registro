using Registro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Registro.ViewModels
{
    public class VerificarCorreoViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://webapi-dctw.onrender.com/api/auth/recuperar/validar-codigo"; // Replace with your actual API URL

        private string _correo;
        private string _codigo1;
        private string _codigo2;
        private string _codigo3;
        private string _codigo4;
        private string _codigo5;
        private string _codigo6;

        public string Correo
        {
            get => _correo;
            set => SetProperty(ref _correo, value);
        }

        public string Codigo1
        {
            get => _codigo1;
            set => SetProperty(ref _codigo1, value);
        }

        public string Codigo2
        {
            get => _codigo2;
            set => SetProperty(ref _codigo2, value);
        }

        public string Codigo3
        {
            get => _codigo3;
            set => SetProperty(ref _codigo3, value);
        }

        public string Codigo4
        {
            get => _codigo4;
            set => SetProperty(ref _codigo4, value);
        }  
        
        public string Codigo5
        {
            get => _codigo5;
            set => SetProperty(ref _codigo5, value);
        }

        public string Codigo6
        {
            get => _codigo6;
            set => SetProperty(ref _codigo6, value);
        }


        //Comandoosss

        public ICommand VerificarCodigoCommand { get; }


        //Metodooosss

        public VerificarCorreoViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _httpClient = new HttpClient();
            VerificarCodigoCommand = new Command(async () => await VerificarCodigo());
        }

        private async Task VerificarCodigo()
        {
            if (string.IsNullOrWhiteSpace(Codigo1) || string.IsNullOrWhiteSpace(Codigo2) ||
                string.IsNullOrWhiteSpace(Codigo3) || string.IsNullOrWhiteSpace(Codigo4) ||
                string.IsNullOrWhiteSpace(Codigo5) || string.IsNullOrWhiteSpace(Codigo6))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, complete todos los campos del código.", "OK");
                return;
            }

            string codigoCompleto = $"{Codigo1}{Codigo2}{Codigo3}{Codigo4}{Codigo5}{Codigo6}";

            var datos = new VerificarCodigo
            {
                correo = Correo,
                codigo = codigoCompleto
            };

            var json = JsonSerializer.Serialize(datos);
            var contenido = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(ApiUrl, contenido);

                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Código verificado correctamente.", "OK");
                    await _navigation.PushAsync(new MainPage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Código incorrecto. Inténtalo de nuevo.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
    }
}
