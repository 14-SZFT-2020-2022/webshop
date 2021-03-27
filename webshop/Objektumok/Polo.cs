using System;
using System.Collections.Generic;

namespace webshop.Objektumok
{
    class Polo
    {
        public string Kod { get; set; }
        public string Megnevezes { get; set; }
        public int Ar { get; set; }
        public int Keszlet { get; set; }

        static public List<Polo> PoloListaLetrohozas(List<string[]> lista)
        {
            List<Polo> poloLista = new List<Polo>();

            foreach (string[] elem in lista)
            {
                // Objektum inicializáló használata.
                Polo polo = new Polo
                {
                    Kod = elem[0],
                    Megnevezes = elem[1],
                    Ar = Int32.Parse(elem[2]),
                    Keszlet = Int32.Parse(elem[3])
                };
                poloLista.Add(polo);
            }

            return poloLista;
        }
    }
}
