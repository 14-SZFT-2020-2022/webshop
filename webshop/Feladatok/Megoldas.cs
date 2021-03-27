using System.Collections.Generic;
using webshop.Filekezeles;
using webshop.Objektumok;

namespace webshop.Feladatok
{
    class Megoldas
    {
        static public void Megoldasok()
        {
            Filebeolvas poloBeolvas = new Filebeolvas("raktar.csv");
            List<Polo> poloLista = Polo.PoloListaLetrohozas(poloBeolvas.Beolvas(';'));

            Filebeolvas rendelesBeolvas = new Filebeolvas("rendeles.csv");
            List<Rendeles> rendelesLista = Rendeles.RendelesListaLetrehozasa(rendelesBeolvas.Beolvas(';'));

            RendelesOsszegzes.RendelesOsszegzesMegoldas(poloLista, rendelesLista);
            Kiertesites.RendelesOsszesites(rendelesLista);

            Beszerzes.BeszerzesOsszesites(poloLista, rendelesLista);
        }
    }
}
