using Abstracciones.Modelo.Servicios.Revision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Servicios
{
    public interface IRevisionServicio
    {
        Task<Revision> Obtener(string placa);
    }
}
