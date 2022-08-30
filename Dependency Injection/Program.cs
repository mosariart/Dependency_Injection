using Autofac;
using System;
using System.Collections.Generic;

namespace AutofacSamples
{
    public interface ILog
    {
        void Write(string message);
    }

    public class ConsoleLog : ILog
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Engine
    {
        private ILog log;
        private int id;

        public Engine(ILog log)
        {
            this.log = log;
            id = new Random().Next();
        }
        public Engine(ILog log, int id)
        {
            this.log = log;
            this.id = id;
        }

        public void Ahead(int power)
        {
            log.Write($"Engine [{id}] ahead {power}");
        }
    }

    public class Car
    {
        private Engine engine;
        private ILog log;

        public Car(Engine engine)
        {
            this.engine = engine;
            this.log = new EmailLog();
        }
        public Car(Engine engine, ILog log)
        {
            this.engine = engine;
            this.log = log;
        }

        public void Go()
        {
            engine.Ahead(100);
            log.Write("Car going forward...");
        }
    }

    public class EmailLog : ILog
    {
        private string EmailAddress = "Addmin@foo.com";
        public void Write(string message)
        {
            Console.WriteLine($"email sent to {EmailAddress} with {message} content");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();


            builder.RegisterGeneric(typeof(List<>)).As(typeof(IList<>));

            IContainer a = builder.Build();

            var b = a.Resolve<IList<int>>();
            Console.WriteLine(b.GetType());
            Console.ReadKey();
        }
    }
}