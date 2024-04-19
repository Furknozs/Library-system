using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    class Kitap
    {

        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public string ISBN { get; set; }
        public int KopyaSayisi { get; set; }
        public int OduncAlinanKopyalar { get; set; }
    }
}
