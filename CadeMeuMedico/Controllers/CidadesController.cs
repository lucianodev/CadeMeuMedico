using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CadeMeuMedico.Models;
using System.Data.Entity;

namespace CadeMeuMedico.Controllers
{
    public class CidadesController : Controller
    {
        private CadeMeuMedicoDBEntities db = new CadeMeuMedicoDBEntities();

        // GET: Cidades
        public ActionResult Index()
        {
            var cidades = db.Cidades.ToList();
            return View(cidades);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Cidades cidade)
        {
            if (ModelState.IsValid )
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        public ActionResult Editar(long id)
        {
            Cidades cidade = db.Cidades.Find(id);
            return View(cidade);
        }

        [HttpPost]
        public ActionResult Editar(Cidades cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

             
        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Cidades cidade = db.Cidades.Find(id);
            if(cidade == null)
            {
                return HttpNotFound();
            }

            return View(cidade);
        }


        // POST: Livros/excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirado(long id)
        {
            Cidades cidade = db.Cidades.Find(id);
            db.Cidades.Remove(cidade );
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}