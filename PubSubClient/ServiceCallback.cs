using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PubSubClient
{
    public class ServiceCallback : IPubSubContract
    {
        public void NameChange(string Name)
        {
            Console.WriteLine("Name: {0}", Name);
        }
    }
}
