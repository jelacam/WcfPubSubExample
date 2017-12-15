
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PubSubClient
{
    public class PubSubProxy : IPubSubService, IDisposable
    {

        private static IPubSubService proxy;
        private static DuplexChannelFactory<IPubSubService> factory;
        private static InstanceContext context;

        public static IPubSubService Instance
        {
            get
            {
                if(proxy == null)
                {
                    context = new InstanceContext(new ServiceCallback());
                    factory = new DuplexChannelFactory<IPubSubService>(context, "*");
                    proxy = factory.CreateChannel();
                }

                return proxy;
            }

            set
            {
                if (proxy == null)
                {
                    proxy = value;
                }
            }
        }


        public void Dispose()
        {
            if(factory != null)
            {
                factory = null;
            }
        }

        public void PublishNameChange(string Name)
        {
            proxy.PublishNameChange(Name);
        }

        public void Subscribe()
        {
            proxy.Subscribe();
        }

        public void Unsubscribe()
        {
            proxy.Unsubscribe();
        }
    }
}
