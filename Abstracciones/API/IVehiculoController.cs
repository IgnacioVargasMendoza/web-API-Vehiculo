using Abstracciones.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.API
{
    public interface IVehiculoController
    {
        Task<IActionResult> Obtener();

        Task<IActionResult> Obtener(Guid Id);

        Task<IActionResult> Agregar(VehiculoRequest vehiculo);

        Task<IActionResult> Editar(Guid Id, VehiculoRequest vehiculo);

        Task<IActionResult> Eliminar(Guid Id);
    }
}
