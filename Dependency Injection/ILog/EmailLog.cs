using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacSamples
{
    public class EmailLog : ILog
    {
        private string EmailAddress = "Addmin@foo.com";
        public void Write(string message)
        {
            Console.WriteLine($"email sent to {EmailAddress} with {message} content");
        }
    }
}
