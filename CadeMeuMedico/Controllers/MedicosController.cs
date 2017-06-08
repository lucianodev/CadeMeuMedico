﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CadeMeuMedico.Models;
using System.Data.Entity;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {
        private CadeMeuMedicoDBEntities db = new CadeMeuMedicoDBEntities();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include(m => m.Cidades).Include(m => m.Especialidades).ToList();

            return View(medicos);
        }

        public ActionResult Adicionar()
        {
            //pegando uma listagem de cidades 
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade );

            return View(medico);
        }

        public ActionResult Editar(long id)
        {
            Medicos medico = db.Medicos.Find(id);

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);
        }


        [HttpPost]
        public ActionResult Editar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);
        }
    }
}