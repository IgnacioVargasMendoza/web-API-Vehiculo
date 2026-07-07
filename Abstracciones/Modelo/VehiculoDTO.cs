using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelo
{
    public class VehiculoBase
    {
        [Required(ErrorMessage = "La placa es requerida")]
        [RegularExpression(@"^[A-Za-z]{3}-[0-9]{3}$", ErrorMessage = "La placa debe tener el formato AAA-999")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "El color es requerido")]
        [StringLength(40, ErrorMessage = "El color no puede tener más de 40 caracteres y menos de 4", MinimumLength = 4)]
        public string Color { get; set; }
        [Required(ErrorMessage = "El año es requerido")]
        [RegularExpression(@"^(19|20)\d\d$", ErrorMessage = "El año debe ser un número de 4 dígitos entre 1900 y 2099")]
        public int Anio { get; set; }
        [Required(ErrorMessage = "El precio es requerido")]
        public Decimal Precio { get; set; }
        [Required(ErrorMessage = "El nombre del propietario es requerido")]
        [EmailAddress]
        public string CorreoPropietario { get; set; }
        [Required(ErrorMessage = "El teléfono del propietario es requerido")]
        [Phone]
        public string TelefonoPropietario { get; set; }
    }

    public class VehiculoRequest : VehiculoBase
    {
        public Guid IdModelo { get; set; }
    }

    public class VehiculoResponse : VehiculoBase
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }
}
    