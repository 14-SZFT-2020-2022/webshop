using System;
using System.Collections.Generic;

namespace webshop.Objektumok
{
    class Rendeles
    {
        public DateTime Datum { get; set; }
        public int RendelesSzama { get; set; }
        public string Email { get; set; }
        public List<(string, int)> RendelesTartalma { get; set; } // Tuple adattípus használata: (string, int), mint generikus.
        public int RendelesOsszege { get; set; } 

        static public List<Rendeles> RendelesListaLetrehozasa(List<string[]> lista)
        {
            List<Rendeles> rendelesLista = new List<Rendeles>();

            foreach (string[] elem in lista)
            {
                if (elem[0] == "M")
                {
                    // Új rendelés létrehozása.
                    Rendeles rendeles = new Rendeles
                    {
                        // Objektum inicializáló használata.
                        Datum = DateTime.Parse(elem[1]),
                        RendelesSzama = Int32.Parse(elem[2]),
                        Email = elem[3],
                        RendelesTartalma = new List<(string, int)>(),
                        // Ez a kiértesítéshez kell, ha 0 marad, akkor nem lehet teljesíteni a rendelést.
                        RendelesOsszege = 0
                    };
                    rendelesLista.Add(rendeles);
                }
                else if (elem[0] == "T")
                {
                    // Az előbb létrehozott rendelés termékekkel való feltöltése.
                    foreach (Rendeles item in rendelesLista)
                    {
                        if (Int32.Parse(elem[1]) == item.RendelesSzama)
                        {
                            item.RendelesTartalma.Add((elem[2], Int32.Parse(elem[3])));
                        }
                    }
                }
            }

            return rendelesLista;
        }
    }
}
