using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace UsuariosMVC.Models
{
    public class Usuario
    {

        public int Usu_Id { get; set; }

        [Display(Name ="Usuario")]
        [Required(ErrorMessage = "*El campo {0} es obligatorio")]
        public string Usu_Name { get; set; }


        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "*El campo {0} es obligatorio")]
        public string Usu_Pass { get; set; }


    }
}