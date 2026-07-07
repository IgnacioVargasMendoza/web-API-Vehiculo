using Abstracciones.Modelo.Servicios.Registro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Servicios
{
    public interface IRegistroServicio
    {
        Task<Propietario> Obtener(string placa);
    }
}
