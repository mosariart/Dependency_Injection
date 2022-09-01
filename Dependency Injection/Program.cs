using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;

namespace AutofacSamples
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<Service>();
            cb.RegisterType<DomainObject>();

            var container = cb.Build();
            //Now we want to build a domainobject,if you look at the DomainObject
            //you will see that Serive in the constructor will be injected automatically
            //but we have to provide the value manually


            //But generally this is not a good way to do it 
            //var dobj = container.Resolve<DomainObject>(new PositionalParameter(1, 42));
            //Console.WriteLine(dobj);

            //we can avoid this using delegate factories
            //in this stage i will add the delegate to the DomainObject class
            var factory = container.Resolve<DomainObject.Factory>();
            var dobj2 = factory(42);
            Console.WriteLine(dobj2);
            Console.ReadKey();
        }
    }
}