using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace UsuariosMVC.Models
{
    public class DomicilioAlumno
    {

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Colonia { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string NoExt { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string NoInt { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string CP { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public int Manzana { get; set; }


    }

}