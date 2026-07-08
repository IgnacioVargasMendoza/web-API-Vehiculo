using Abstracciones.Reglas;
using Abstracciones.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class RegistroReglas : IRegistroReglas
    {
        private IRegistroServicio _registroServicio;
        private IConfiguracion _configuracion;

        public RegistroReglas(IRegistroServicio registroServicio, IConfiguracion configuracion)
        {
            _registroServicio = registroServicio;
            _configuracion = configuracion;
        }

        public async Task<bool> VehiculoEstadoRegistro(string placa, string email)
        {
            var resultado = await _registroServicio.Obtener(placa);
            return (resultado != null && resultado.Email == email);
        }
    }
}
