using Newtonsoft.Json;
using Registro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.ViewModels
{
    public class PantallaPrincipalViewModel : BaseViewModel
    {
        private ObservableCollection<DispensadorModel> _dispensadores;

        public ObservableCollection<DispensadorModel> Dispensadores
        {
            get => _dispensadores;
            set => SetProperty(ref _dispensadores, value);
        }


        public PantallaPrincipalViewModel()
        {
            Dispensadores = new ObservableCollection<DispensadorModel>();
            CargarDispensadores();
        }

        public async Task CargarDispensadores()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync("https://webapi-dctw.onrender.com/api/dispensadores");
                var dispensadoresList = JsonConvert.DeserializeObject<List<DispensadorModel>>(response);
                Dispensadores.Clear();
                foreach (var dispensador in dispensadoresList)
                {
                    Dispensadores.Add(dispensador);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al cargar dispensadores: {ex.Message}");
            }


        }
    }
}