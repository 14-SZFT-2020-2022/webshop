using System.Collections.Generic;
using webshop.Objektumok;
using webshop.Filekezeles;

namespace webshop.Feladatok
{
    class Beszerzes
    {
        static public void BeszerzesOsszesites(List<Polo> poloLista, List<Rendeles> rendelesLista)
        {
            string kiir = "";

            foreach (Polo elem in poloLista)
            {
                foreach (Rendeles item in rendelesLista)
                {
                    if (item.RendelesOsszege == 0)
                    {
                        foreach ((string, int) tetel in item.RendelesTartalma)
                        {
                            // Ha a rendelés nem teljesíthető, akkor minden tételét vonjam ki a vonatkozó raktárkészletekből.
                            if (elem.Kod == tetel.Item1)
                            {
                                elem.Keszlet = elem.Keszlet - tetel.Item2;
                            }
                        }
                    }
                }
            }

            foreach (Polo elem in poloLista)
            {
                // Ha a készlet kisebb, mint nulla, akkor rendeljem meg a (-1)szeresét, így minden rendelés teljesíthetővé válik.
                if (elem.Keszlet < 0)
                {
                    kiir += $"{elem.Kod};{-elem.Keszlet}\n";
                }
            }

            Filebakiir kiiras = new Filebakiir("beszerzes.csv");
            kiiras.Kiiras(kiir);
        }
    }
}
