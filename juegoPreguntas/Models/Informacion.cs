using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace juegoPreguntas.Models
{
    public class Informacion
    {

        string respuestaCorrecta;
        string respuestaSeleccionada;
        int nivelSuperado;
 



        public Informacion(string respuestaCorrecta, string respuestaSeleccionada, int nivelSuperado)
        {
            this.respuestaCorrecta = respuestaCorrecta;
            this.respuestaSeleccionada = respuestaSeleccionada;
            this.nivelSuperado = nivelSuperado;
        
        }

        

        public int getNivel()
        {
            return this.nivelSuperado;
        }


        public int calcularPuntaje()
        {

            int puntaje = 0;

            for (int i = 1; i <= this.nivelSuperado; i++)
            {

                if(i > juegoPreguntas.Controllers.PartidasController.MAXIMONIVEL)
                {
                    return puntaje;
                }
                else
                {
                    puntaje = puntaje + (i * 100);
                }
              
            }

            return puntaje;
        }

        public bool compararRespuestas()
        {

            if (this.respuestaCorrecta.Equals(respuestaSeleccionada))
            {
                return true;
            }
            else
            {
                return false;
            }


        }


    }
}