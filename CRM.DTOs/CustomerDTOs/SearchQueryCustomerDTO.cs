﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DTOs.CustomerDTOs
{
    public class SearchQueryCustomerDTO
    {
        [Display(Name = "Nombre")]
        public string? Name_Like { get; set; }

        [Display(Name = "Apellido")]
        public string? LastName_Like { get; set; }

        [Display(Name = "Página")]
        public int Skip { get; set; }

        [Display(Name = "CantReg X Página")]
        public int Take { get; set; }

        /// <summary>
        /// 1 = No se cuenta los resultados de la búsqueda
        /// 2 = Cuenta los resultados de la búsqueda
        /// </summary>
        public byte SendRowCount { get; set; }
    }
}
