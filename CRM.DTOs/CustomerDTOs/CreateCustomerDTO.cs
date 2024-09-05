using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRM.DTOs.CustomerDTOs
{
    public class CreateCustomerDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Raza")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El campo Apellido no puede tener más de 30 caracteres.")]
        public string LastName { get; set; }

        [Display(Name = "Direccion")]
        [Range(0, 30, ErrorMessage = "La direccion no puede tener mas de 255 caracteres")]
        public string? Address { get; set; }
    }
}
