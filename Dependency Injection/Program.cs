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
            //delegate factories allow you to create objects on demand
            var cb = new ContainerBuilder();
            cb.RegisterType<Entity>().InstancePerDependency();
            cb.RegisterType<ViewModel>();

            var container = cb.Build();
            var vm = container.Resolve<ViewModel>();
            vm.Method();
            vm.Method();
            Console.ReadKey();
        }
    }
}