using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using juegoPreguntas;
using juegoPreguntas.Models;


namespace juegoPreguntas.Controllers
{
    public class PartidasController : Controller
    {
        private JuegoPreguntasEntities db = new JuegoPreguntasEntities();
        public Partida Mipartida = new Partida();
        public const int MAXIMONIVEL = 5;

        // GET: Partidas
        public ActionResult Index()
        {
            return View(db.Partida.ToList());
        }


        public ActionResult validacionRespuesta(FormCollection frm)
        {

            var respuestaRadio = frm["Respuesta"].ToString();
            string[] substrings = respuestaRadio.Split('/');

            int id = Int32.Parse(substrings[0]);
            var respuestaSeleccionada = substrings[1];


            JuegoPreguntasEntities db = new JuegoPreguntasEntities();
            var preguntaRealizada = db.Preguntas.Find(id);
            var respuestaCorrecta = preguntaRealizada.correcta;
            int nivel = Int32.Parse(preguntaRealizada.categoria.ToString());


            Informacion info = new Informacion(respuestaCorrecta, respuestaSeleccionada, nivel);

            List<Informacion> listaInfo = new List<Informacion>();

            listaInfo.Add(info);


            return View(listaInfo);



        }

        public ActionResult lanzarPregunta(int categoriaNivel)
        {


            if (categoriaNivel > MAXIMONIVEL)
            {
                var pregunta = new Preguntas();
                pregunta.categoria = MAXIMONIVEL + 1;
                List<Preguntas> preguntas = new List<Preguntas>();
                preguntas.Add(pregunta);
                return View(preguntas);
            }
            else
            {
                Mipartida.nivel = categoriaNivel;
                Mipartida.puntuacion = Mipartida.puntuacion + (categoriaNivel * 100);
                var preguntas = db.Preguntas.Where(c => c.categoria == categoriaNivel).ToList();
                return View(preguntas);
            }




        }


        public ActionResult vistaFinal(string puntajeEstado)
        {
            string[] substrings = puntajeEstado.Split('/');
            var nivel = Int32.Parse(substrings[0]); ;
            var puntuacion = substrings[1]; ;
            var resultado = substrings[2]; ;


            var partida = new Partida()
            {
                resultado = resultado,
                puntuacion = puntuacion,
                nombreJugador = DateTime.Now.ToString(),
                nivel = nivel,

            };

            db.Partida.Add(partida);
            db.SaveChanges();
            return View();
        }


        // GET: Partidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida partida = db.Partida.Find(id);
            if (partida == null)
            {
                return HttpNotFound();
            }
            return View(partida);
        }

        // GET: Partidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombreJugador,puntuacion,nivel,resultado,idPartida")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                db.Partida.Add(partida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partida);
        }

        // GET: Partidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida partida = db.Partida.Find(id);
            if (partida == null)
            {
                return HttpNotFound();
            }
            return View(partida);
        }

        // POST: Partidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombreJugador,puntuacion,nivel,resultado,idPartida")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partida);
        }

        // GET: Partidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida partida = db.Partida.Find(id);
            if (partida == null)
            {
                return HttpNotFound();
            }
            return View(partida);
        }

        // POST: Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partida partida = db.Partida.Find(id);
            db.Partida.Remove(partida);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }





    }
}
