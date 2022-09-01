using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacSamples
{
    public class Entity
    {
        public delegate Entity Factory();
        private static Random random = new Random();
        private int number;
        public Entity()
        {
            number = random.Next();
        }
        public override string ToString()
        {
            return "test" + number;
        }
    }
}
