using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacSamples
{
    public class ViewModel
    {
        private readonly Entity.Factory entityfactory;
        public ViewModel(Entity.Factory entityFactory)
        {
            entityfactory = entityFactory;
        }
        public void Method()
        {
            var entity = entityfactory();
            Console.WriteLine(entity);
        }
    }
}
