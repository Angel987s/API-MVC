using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DTOs.CustomerDTOs
{
    public class EditCustomerDTO
    {

        public EditCustomerDTO(GetIdResultCustomerDTO getIdResultCustomerDTO) 
        {
            Id = getIdResultCustomerDTO.Id;
            Name = getIdResultCustomerDTO.Name;
            LastName = getIdResultCustomerDTO.LastName;
            Address= getIdResultCustomerDTO.Address;

        }

        public EditCustomerDTO() {
            Name = string.Empty;
            LastName = string.Empty;
        }

        [Required(ErrorMessage = "El campo ID es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Raza")]
        [Required(ErrorMessage = "El campo Raza es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El campo Raza no puede tener más de 30 caracteres.")]
        public string LastName { get; set; }

        [Display(Name = "Direccion")]
        [Range(0, 30, ErrorMessage = "La direccion no puede tener mas de 255 caracteres")]
        public string? Address { get; set; }
    }
}
