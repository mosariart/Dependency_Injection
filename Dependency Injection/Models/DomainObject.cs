using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacSamples
{
    public class DomainObject
    {
        private Service service;
        private int value;

        //in this delegate you add those parameters that are not 
        //automatically injected,like value in this case
        public delegate DomainObject Factory(int value);
        public DomainObject(Service service, int value)
        {
            this.service = service;
            this.value = value;
        }
        public override string ToString()
        {
            return service.DoSomething(value);
        }
    }
}
