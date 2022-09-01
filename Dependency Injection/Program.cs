using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutofacSamples
{
    internal class Program
    { 
        public static void Main(string[] args)
        {
            //registering all the types in the assembly at once
            var assembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();
            //here we are registering all the types together
            // builder.RegisterAssemblyTypes(assembly);

            //but we can customize that either,we can use linq to exclude 
            //a special type or ....
            builder.RegisterAssemblyTypes(assembly)
                 .Where(t => t.Name.EndsWith("Log"))
                 .Except<SMSLog>()
                 .Except<ConsoleLog>(c => c.As<ILog>().SingleInstance())
                 .AsSelf();
        }
    }
}