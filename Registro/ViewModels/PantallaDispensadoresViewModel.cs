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
    public class PantallaDispensadoresViewModel : BaseViewModel
    {
        private double _cantidadGramos;
        private string _gramosTexto;

        public double CantidadGramos
        {
            get => _cantidadGramos;
            set
            {
                SetProperty(ref _cantidadGramos, value);
                GramosTexto = $"Cantidad: {(int)value} g";
            }
        }

        public string GramosTexto
        {
            get => _gramosTexto;
            set => SetProperty(ref _gramosTexto, value);
        }


        //comandooos

        public ICommand DispensarComidaCommand { get; }

        private readonly HttpClient _httpClient;


        public PantallaDispensadoresViewModel()
        {
            CantidadGramos = 50;
            DispensarComidaCommand = new Command(async () => await DispensarComida());
        }

        private async Task DispensarComida()
        {
            try
            {
                var httpClient = new HttpClient();
                var url = "https://webapi-dctw.onrender.com/api/dispensadores/{67f30c0c59144b1312ef947d }/dispensar-manual"; // Cambia esto por tu endpoint real

                var request = new DispensadorRequest
                {
                    cantidadGramos = (int)CantidadGramos
                };

                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "La comida fue dispensada correctamente.", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo dispensar la comida.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Hubo un error: {ex.Message}", "OK");
            }
        }

    }
}
