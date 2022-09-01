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
            var builder = new ContainerBuilder();
            builder.RegisterType<Parent>();

            //Below we have to ways of property injection

            //the first way
            //here the system will go through all the properties and try to resolve it
            //builder.RegisterType<Child>().PropertiesAutowired();

            //the second way 
            //builder.RegisterType<Child>()
            //    .WithProperty("Parent", new Parent());

            //var container = builder.Build();
            //var parent = container.Resolve<Child>().Parent;
            //Console.WriteLine(parent);
            //Console.ReadKey();

            //============================================================//
            //Below we talk about method dependency.
            //which means a method which is defined to inject the dependency.
            //in this way we are not only registering a class but also registering
            //it in a way that we have assigned a property by calling a particular method.
            builder.Register(c =>
            {
                var child = new Child();
                child.SetParent(c.Resolve<Parent>());
                return child;
            });
            var container = builder.Build();
            var parent = container.Resolve<Child>().Parent;
            Console.WriteLine(parent);
            Console.ReadKey();
        }
    }
}