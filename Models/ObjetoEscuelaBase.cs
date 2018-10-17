using System;

namespace platzi_asp_net_core.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}