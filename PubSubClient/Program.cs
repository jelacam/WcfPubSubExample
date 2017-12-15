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

            Console.ReadKey();
            
        }
    }
}
