using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Business.Entities
{
    public class Card
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public string Type { get; set; }
        public string Attack1 { get; set; }
        public string Attack2 { get; set; }
        public string Weakness { get; set; }
        public string Resistance { get; set; }
        public int Generation { get; set; }
    }
}
