using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using juegoPreguntas;

namespace juegoPreguntas.Controllers
{
    public class PartidasController : Controller
    {
        private JuegoPreguntasEntities db = new JuegoPreguntasEntities();
        public Partida Mipartida = new Partida();

        // GET: Partidas
        public ActionResult Index()
        {
            return View(db.Partida.ToList());
        }


        public ActionResult validacionRespuesta(FormCollection frm)
        {

            var respuestaRadio = frm["Respuesta"].ToString();

            string[] substrings = respuestaRadio.Split('/');

    
            return View(substrings);



        }

        public ActionResult lanzarPregunta(int categoriaNivel)
        {
    
            Mipartida.nivel = categoriaNivel;
            Mipartida.puntuacion = Mipartida.puntuacion + (categoriaNivel * 100);

            var preguntas = db.Preguntas.Where(c => c.categoria == categoriaNivel).ToList();

            return View(preguntas);

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
