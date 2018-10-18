using System;
using System.Collections.Generic;

namespace platzi_asp_net_core.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; } 
    }
}