using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PubSubClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test");

            PubSubProxy.Instance.Subscribe();

            Console.WriteLine("Press <Enter> to unsubscribe.");
            Console.ReadKey();

            PubSubProxy.Instance.Unsubscribe();

            Console.WriteLine("Press <Enter> to subscribe");
            Console.ReadKey();

            PubSubProxy.Instance.Subscribe();

            Console.WriteLine("Press <Enter> to end");
            Console.ReadKey();
            
        }
    }
}
