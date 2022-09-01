using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacSamples
{
    public class Service
    {
        public string DoSomething(int value)
        {
            return $"I have {value}";
        }
    }
}
