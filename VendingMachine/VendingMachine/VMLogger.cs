using System;
using Castle.Core.Logging;

namespace VendingMachine
{
    public class VMLogger : IVendingMachineLogger
    {
        //Developer can Inject different type of logging framework here
        public void DebugLog(string message)
        {
         Console.WriteLine("Debug Log:" + message);
        }

        public void ErrorLog(string message)
        {
            Console.WriteLine("Error Log:" + message);

        }
    }
}