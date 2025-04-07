using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Registro.Models;
using Registro.Service;


namespace Registro.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
       private readonly HttpClient _httpClient;
        private const string ApiURL = "https://webapi-dctw.onrender.com/api/auth/login"; // Cambia esto por la URL de tu API

        private string _correo;
        private string _contraseña;
        private bool _isPasswordVisible = true;
        private string _mensajeError;
        private string _eyeicon = "ojocerrado.png";
        private readonly INavigation _navigation;
        private string _Msgemail;
        private string _Msgpassword;

        public string Correo
        {
            get { return _Msgemail; }
            set { if (_Msgemail != value) { _Msgemail = value; OnPropertyChanged(nameof(_Msgemail)); } }
        }

        public string Contraseña
        {
            get => _contraseña;
            set => SetProperty(ref _contraseña, value);
        }

        public bool IsPasswordVisible
        {
            get => _isPasswordVisible;
            set
            {
                _isPasswordVisible = value;
                OnPropertyChanged(nameof(IsPasswordVisible));
                EyeIcon = _isPasswordVisible ? "ojocerrado.png" : "ojoabierto.png";
            }
        }

        public string MsgEmail
        {
            get { return _Msgemail; }
            set { if (_Msgemail != value) { _Msgemail = MsgEmail; OnPropertyChanged(nameof(MsgEmail)); } }
        }

        public string MsgPassword
        {
           get { return _Msgpassword; }
           set { if (_Msgpassword != value) { _Msgpassword = value; OnPropertyChanged(nameof(MsgPassword)); } }

        }

        public string EyeIcon
        {
           get => _eyeicon;
            set
            {
                _eyeicon = value;
                OnPropertyChanged(nameof(EyeIcon));
            }
        }

        public string MensajeError
        {
            get => _mensajeError;
            set => SetProperty(ref _mensajeError, value);
        }

        //Comandos

        public ICommand LoginCommand { get; }
        public ICommand PasswordCommand { get; }
        public ICommand RecuperarContraCommand { get; }
        public ICommand CrearCuentaCommand { get; }
        public ICommand ValidacionCommand { get; }

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _httpClient = new HttpClient();
            LoginCommand = new Command(async () => await Login());
            PasswordCommand = new Command (CambiarContra);
            RecuperarContraCommand = new Command(async () => await NavegarRcuperarContra());
            CrearCuentaCommand = new Command(async () => await CrearCuenta());
            ValidacionCommand = new Command(async () => await ValidarCampos());
        }

        //Metodooosssss

        private async Task Login()
        {
            MensajeError = string.Empty;

            await ValidarCampos();

            if (!string.IsNullOrEmpty(MensajeError))
            {
                return; // Si hay error, no se ejecuta la llamada a la API
            }

            var datosLogin = new LoginUser
            {
                correo = Correo,
                contraseña = Contraseña
            };

            var json = JsonSerializer.Serialize(datosLogin);
            var contenido = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(ApiURL, contenido);

                if (response.IsSuccessStatusCode)
                {
                    string token = await response.Content.ReadAsStringAsync();
                    await AuthService.GuardarToken(token);

                    // Redirigir a la pantalla principal, reemplazando la actual
                    Application.Current.MainPage = new NavigationPage(new PantallaPrincipal());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Credenciales Incorrectas, favor de validar", "Ok");
                }
            }
            catch (Exception ex)
            {
                MensajeError += ex.Message;
            }
        }

        private void CambiarContra()
        {
            IsPasswordVisible = !IsPasswordVisible;
            EyeIcon = IsPasswordVisible ? "ojocerrado.png" : "ojoabierto.png";
        }

        public async Task CrearCuenta()
        {
            await _navigation.PushAsync(new Registro());
        }

        public async Task NavegarRcuperarContra()
        {
            await _navigation.PushAsync(new correo());
        }

        private async Task ValidarCampos()
        {
            MensajeError = string.Empty;
            if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(Contraseña))
            {
                MensajeError = "Todos los campos son obligatorios.";
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(Correo, emailPattern))
            {
                MensajeError = "El email debe ser un correo válido.";
                return;
            }
        }

    }
    
    
}
