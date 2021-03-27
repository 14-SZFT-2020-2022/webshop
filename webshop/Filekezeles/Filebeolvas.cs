using System.Collections.Generic;
using System.Text;
using System.IO;

namespace webshop.Filekezeles
{
    class Filebeolvas
    {
        public string FileNev { get; set; }

        public Filebeolvas(string fileNev)
        {
            this.FileNev = fileNev;
        }

        public List<string[]> Beolvas(char delimiter)
        {
            List<string[]> lista = new List<string[]>();

            using (StreamReader sr = new StreamReader(this.FileNev, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine().Trim();
                    string[] tomb = sor.Split(delimiter);
                    lista.Add(tomb);
                }
            }

                return lista;
        }
    }
}
