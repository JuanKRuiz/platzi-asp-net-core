using System;
using System.ComponentModel.DataAnnotations;

namespace platzi_asp_net_core.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }
        
        public virtual string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}