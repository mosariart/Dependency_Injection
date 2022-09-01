using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacSamples
{
    public class SMSLog : ILog
    {
        public string phoneNumber;
        public SMSLog(string PhoneNumber)
        {
            phoneNumber = PhoneNumber;
        }
        public void Write(string message)
        {
            Console.WriteLine($"SMS to {phoneNumber} and message is {message}");
        }
    }
}
