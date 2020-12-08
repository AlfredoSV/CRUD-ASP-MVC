using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UsuariosMVC.Models
{
    public class Alumno : DomicilioAlumno
    {
        
        public int Id_Alumno { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [StringLength(maximumLength:50)]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Text)]
        public string ApellidoP { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Text)]
        public string ApellidoM { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        public int Edad { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        [DataType(DataType.PhoneNumber)]
        public string Num1 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [DataType(DataType.PhoneNumber)]
        public string Num2 { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Num3 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [EmailAddress(ErrorMessage ="Favor de ingresar un correo electrónico valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Carrera { get; set; }


        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Campus { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string HermanosInstitu { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]        
        public decimal PromedioMedioSup { get; set; }


    }

}