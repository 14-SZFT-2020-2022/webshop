using System.Collections.Generic;
using webshop.Objektumok;
using webshop.Filekezeles;

namespace webshop.Feladatok
{
    class Kiertesites
    {
        static public void RendelesOsszesites(List<Rendeles> lista)
        {
            string kiir = "";

            foreach (Rendeles elem in lista)
            {
                // Ha rendelés nem teljesíthető.
                if (elem.RendelesOsszege == 0)
                {
                    kiir += $"{elem.Email};A rendelése függő állapotba került. Hamarosan értesítjük a szállítás időpontjáról.\n";
                }
                // Ha a rendelés teljesíthető.
                else
                {
                    kiir += $"{elem.Email};A rendelését két napon belül szállítjuk. A rendelés értéke {elem.RendelesOsszege} Ft.\n";
                }
            }

            Filebakiir kiiras = new Filebakiir("levelek.csv");
            kiiras.Kiiras(kiir);
        }
    }
}
