using Registro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Registro.ViewModels
{
    public class RegistrarViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private HttpClient _httpClient;
        private const string ApiURL = "https://webapi-dctw.onrender.com/api/auth/register"; // Cambia esto por la URL de tu API


        private string _nombre;
        private string _correo;
        private string _contraseña;
        private string _mensajeError;
        private bool _isPasswordVisible = true;
        private string _ojoIcono = "ojocerrado.png";


        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        public string Correo
        {
            get => _correo;
            set => SetProperty(ref _correo, value);
        }

        public string Contraseña
        {
            get => _contraseña;
            set => SetProperty(ref _contraseña, value);
        }

        public string MensajeError
        {
            get => _mensajeError;
            set => SetProperty(ref _mensajeError, value);
        }

        public bool IsPasswordVisible
        {
            get => _isPasswordVisible;
            set
            {
                _isPasswordVisible = value;
                OnPropertyChanged();
                OjoIcono = _isPasswordVisible ? "ojocerrado.png" : "ojoabierto.png";
            }
        }

        public string OjoIcono
        {
            get => _ojoIcono;
            set => SetProperty(ref _ojoIcono, value);
        }



        //comandooosss
        public ICommand VerOjoContraCommand { get; }
        public ICommand RegisterCommand { get; }

        //Metodoooooss

        public RegistrarViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _httpClient = new HttpClient();

            //inicializar comandos
            RegisterCommand = new Command(async () => await RegistrarUsuario());
            VerOjoContraCommand = new Command(VerOjoContra);
        }

        private async Task RegistrarUsuario()
        {
            MensajeError = string.Empty;

            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Correo) || string.IsNullOrWhiteSpace(Contraseña))
            {
                MensajeError = "Todos los campos son obligatorios.";
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(Correo, emailPattern))
            {
                MensajeError = "El correo no es válido.";
                return;
            }

            var usuario = new Users
            {
                nombre = Nombre,
                correo = Correo,
                contraseña = Contraseña
            };

            var json = JsonSerializer.Serialize(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(ApiURL, content);
                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
                    await _navigation.PopAsync();
                }
                else
                {
                    MensajeError = "Error al registrar. Verifica los datos.";
                }
            }
            catch (Exception ex)
            {
                MensajeError = $"Error: {ex.Message}";
            }
        }
        private void VerOjoContra()
        {
            IsPasswordVisible = !IsPasswordVisible;
        }
    }
    
}
