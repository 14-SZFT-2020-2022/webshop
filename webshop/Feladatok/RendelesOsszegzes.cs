using System.Collections.Generic;
using webshop.Objektumok;

namespace webshop.Feladatok
{
    class RendelesOsszegzes
    {
        static public void RendelesOsszegzesMegoldas(List<Polo> poloLista, List<Rendeles> rendelesLista)
        {
            foreach (Rendeles elem in rendelesLista)
            {
                // Megnézzük, hogy egy rendelés tejesíthető-e a raktárból.
                bool teljesithetoE = true;
                
                foreach ((string, int) tetel in elem.RendelesTartalma)
                {
                    foreach (Polo item in poloLista)
                    {
                        // Van-e elegendő készlet a rendelt tételből?
                        if (item.Kod == tetel.Item1 && (item.Keszlet - tetel.Item2) < 0)
                        {
                            // Ha nincs, akkor ne keress tovább!
                            teljesithetoE = false;
                            break;
                        }
                    }
                }

                // Ha van elég készlet a raktárban, akkor csökkentsük a készletet és számoljuk ki a rendelés összárát.
                if (teljesithetoE)
                {
                    foreach ((string, int) tetel in elem.RendelesTartalma)
                    {
                        foreach (Polo item in poloLista)
                        {
                            if (item.Kod == tetel.Item1)
                            {
                                item.Keszlet = item.Keszlet - tetel.Item2;
                                elem.RendelesOsszege += item.Ar * tetel.Item2;
                            }
                        }
                    }
                }
            }
        }
    }
}
