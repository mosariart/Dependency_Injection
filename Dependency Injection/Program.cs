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


            
            //builder.RegisterType<EmailLog>().As<ILog>();
            //builder.RegisterType<ConsoleLog>().As<ILog>().PreserveExistingDefaults();
            

            builder.RegisterType<Engine>();
            builder.RegisterType<Car>();



            //named parameter
            //builder.RegisterType<SMSLog>()
            //    .As<ILog>()
            //    .WithParameter("phoneNumber", "+123345456");

            //typed parameter
            //builder.RegisterType<SMSLog>()
            //    .As<ILog>()
            //    .WithParameter(new TypedParameter(typeof(string), "+123345456"));

            //resolved parameter
            builder.RegisterType<SMSLog>()
                .As<ILog>()
                .WithParameter(
                new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "PhoneNumber",
                    (pi, ctx) => "+123345456"));

            
            var container = builder.Build();
            var log = container.Resolve<ILog>();
            log.Write("text message");

            Console.ReadKey();

        }
    }
}