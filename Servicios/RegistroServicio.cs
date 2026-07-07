using Abstracciones.Modelo.Servicios.Registro;
using Abstracciones.Reglas;
using Abstracciones.Servicios;
using System.Text.Json;

namespace Servicios
{
    public class RegistroServicio : IRegistroServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClientFactory;

        public RegistroServicio(IConfiguracion configuracion, IHttpClientFactory httpClientFactory)
        {
            _configuracion = configuracion;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Propietario> Obtener(string placa)
        {
            var endpoint = _configuracion.ObtenerMetodo("ApiEndPointsRegistro", "ObtenerRegistro");
            var servicio = _httpClientFactory.CreateClient("ServicioRegistro");
            var respuesta = await servicio.GetAsync(string.Format(endpoint, placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var resultadoDeserializado = JsonSerializer.Deserialize<List<Propietario>>(resultado, opciones);
            return resultadoDeserializado.FirstOrDefault();
        }
    }
}
