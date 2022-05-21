using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacture
{
    public class Cargo
    {
        public Cargo(string type, int weiht)
        {
            Type = type;
            Weiht = weiht;
        }

        public string Type { get; set; }
        public int Weiht { get; set; }
    }
}
