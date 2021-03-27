using System.Text;
using System.IO;

namespace webshop.Filekezeles
{
    class Filebakiir
    {
        public string FileNev { get; set; }

        public Filebakiir(string fileNev)
        {
            this.FileNev = fileNev;
        }

        public void Kiiras(string kiir)
        {
            using (StreamWriter sw = new StreamWriter(this.FileNev, false, Encoding.UTF8))
            {
                sw.Write(kiir);
            }
        }
    }
}
