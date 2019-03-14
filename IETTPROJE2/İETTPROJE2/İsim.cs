using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İETTPROJE2
{
    class İsim
    {
        public double ID { get; set; }
        public double isimXkoordinat { get; set; }
        public double isimYkoordinat { get; set; }


        public override string ToString()
        {
            return $"{ID}{isimXkoordinat}{isimYkoordinat}";
        }
    }
}
