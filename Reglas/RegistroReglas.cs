using Abstracciones.Modelo.Servicios.Revision;
using Abstracciones.Reglas;
using Abstracciones.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class RevisionReglas : IRevisionReglas
    {
        private IRevisionServicio _revisionServicio;
        private IConfiguracion _configuracion;

        public RevisionReglas(IRevisionServicio revisionServicio, IConfiguracion configuracion)
        {
            _revisionServicio = revisionServicio;
            _configuracion = configuracion;
        }

        public async Task<bool> RevisionEsValida(string placa)
        {
            var resultado = await _revisionServicio.Obtener(placa);
            if(ValidarEstado(resultado) && ValidarPeriodo(resultado.Periodo))
            {
                return true;
            }
            return false;
        }

        private static bool ValidarEstado(Revision resultadoRevision)
        {
            return resultadoRevision.Resultado.Equals("Favorable", StringComparison.OrdinalIgnoreCase);
        }
        private static string ObtenerPeriodoActual() { 
            return $"{DateTime.Now.Month}-{DateTime.Now.Year}";
        }
        private static bool ValidarPeriodo(string periodo)
        { 
            var periodoActual = ObtenerPeriodoActual();
            return periodo == periodoActual;
        }
    }
}
