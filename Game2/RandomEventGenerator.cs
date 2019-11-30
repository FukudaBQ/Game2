using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class RandomEventGenerator
    {
        int rm;
        public void generateEvent()
        {
            Random random = new Random();
            rm = random.Next(10);
            
        }
    }
}
