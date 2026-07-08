using Abstracciones.Modelo.Servicios.Registro;
using Abstracciones.Modelo.Servicios.Revision;
using Abstracciones.Reglas;
using Abstracciones.Servicios;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Servicios
{
    public class RevisionServicio : IRevisionServicio
    {
        private readonly IConfiguracion _configuracionServicio;
        private readonly IHttpClientFactory _httpClientFactory;

        public RevisionServicio(IConfiguracion configuracionServicio, IHttpClientFactory httpClientFactory)
        {
            _configuracionServicio = configuracionServicio;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Revision> Obtener(string placa)
        {
            var endpoint = _configuracionServicio.ObtenerMetodo("ApiEndPointsRevision", "ObtenerRevision");
            var servicio = _httpClientFactory.CreateClient("ServicioRevision");
            var respuesta = await servicio.GetAsync(string.Format(endpoint, placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var resultadoDeserializado = JsonSerializer.Deserialize<List<Revision>>(resultado, opciones);
            return resultadoDeserializado.FirstOrDefault();
        }
    }
}
