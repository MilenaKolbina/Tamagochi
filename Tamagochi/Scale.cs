using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
    class Scale
    {
        public int max_value = 100;
        public int current_value;

        public Scale()
        {
            current_value = 0;
            max_value = 0;
        }


        public Scale(int _current_value)
        {
            current_value = _current_value;
            max_value = 0;
        }
    }
}
