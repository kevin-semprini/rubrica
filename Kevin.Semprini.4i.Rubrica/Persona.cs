using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kevin.Semprini._4i.Rubrica
{
    class Persona
    {

        private int _numero;
        private string _nome;
        private string _cognome;


        public string Nome { get; set;}
        public string Cognome { get; set;}
        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _numero = value;
                }
            }
        }

        public Persona(string riga)
        {
            // ".split()" crea una vettore di elemnti stringa
            string[] campi = riga.Split(';');
            int PK = 0;

            int.TryParse(campi[0], out PK);
            this.Numero = PK;
            string PKstr = PK.ToString();
            if (PKstr == "PK") { this.Numero = 1; }

            this.Nome = campi[1];
            this.Cognome = campi[2];
            //tryParse serve a convertire il valore dato come primo paramentro in un valore di tipo "int"
            //in questoc caso, e metterlo nella variabile PK che è di tipo int, è sempre stringa > var
            //in pratica lui controlla la stringa e prende  il valore richiesto dalla variabile messa
        }

        public Persona() { }
    }
}
