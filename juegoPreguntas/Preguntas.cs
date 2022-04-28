

namespace juegoPreguntas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Preguntas
    {


        [Display(Name = "#")]
        public int idPregunta { get; set; }

        [Required(ErrorMessage = "Debes ingresar {0}")]
        [Display(Name = "Enunciado")]
        public string enunciado { get; set; }

        [Display(Name = "Respuesta correcta")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public string correcta { get; set; }

        [Display(Name = "Incorrecta 1")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public string incorrecta1 { get; set; }


        [Display(Name = "Incorrecta 2")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public string incorrecta2 { get; set; }

        [Display(Name = "Incorrecta 3")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public string incorrecta3 { get; set; }

        [Display(Name = "Categoria/Dificultad")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [Range(1,5, ErrorMessage = "El valor {0} debe estar entre 1 y 5 ")]
        public Nullable<int> categoria { get; set; }

    }
}
