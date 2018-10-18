using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                        var curso = from cur in _context.Cursos
                                        where cur.Id == id
                                        select cur;

                        return View(curso.SingleOrDefault());
            }
            else
            {
               return View("MultiCurso", _context.Cursos); 
            }
        }

        public IActionResult MultiCurso()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAlumno", _context.Cursos);
        }
        
        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
           _context = context; 
        }
    }
}