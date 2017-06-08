using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class MensagensController : Controller
    {
       

        public ActionResult BomDia()
        {
            return Content("Bom dia, hoje vc acordou cedo!");
        }

        public ActionResult BomTarde()
        {
            return Content("Bom tarde!");
        }
    }
}