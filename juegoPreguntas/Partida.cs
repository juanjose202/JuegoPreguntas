

namespace juegoPreguntas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Partida
    {

        [Display(Name = "Fecha juego")]
        public string nombreJugador { get; set; }


        [Display(Name = "Puntuación")]
        public string puntuacion { get; set; }

        [Display(Name = "Nivel alcanzado")]
        public Nullable<int> nivel { get; set; }


        [Display(Name = "Resultado")]
        public string resultado { get; set; }


        [Display(Name = "#")]
        public int idPartida { get; set; }
    }
}
