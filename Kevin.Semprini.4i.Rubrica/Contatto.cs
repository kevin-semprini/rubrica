using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kevin.Semprini._4i.Rubrica
{
    public enum TipiDato
    {
        Nessuno,
        Email,
        Telefono,
        Web,
    }
    internal class Contatto
    {
        public int IdPersona {  get; set; } 
        public TipiDato tipo { get; set; }
        public string Valore { get; set; }

        public Contatto(Persona p)
        {
            IdPersona = p.Numero;
            tipo = TipiDato.Nessuno;
        }

        public Contatto(string riga)
        {
            string[] dati = riga.Split(';');

            int amoguss;
            int.TryParse(dati[0], out amoguss);
            this.IdPersona = amoguss;

            TipiDato amogus;
            Enum.TryParse(dati[1], out amogus);
            this.tipo = amogus;

            this.Valore = dati[2];
        }

    }
}

