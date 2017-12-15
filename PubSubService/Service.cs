using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace PubSubService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service : IPubSubService
    {
        public delegate void NameChangeEventHandler(object sender, ServiceEventArgs e);
        public static event NameChangeEventHandler NameChangeEvent;

        IPubSubContract ServiceCallback = null;
        NameChangeEventHandler NameHandler = null;



        public void PublishNameChange(string Name)
        {
            ServiceEventArgs se = new ServiceEventArgs();
            se.Name = Name;
            NameChangeEvent(this, se);
        }

        public void Subscribe()
        {
            ServiceCallback = OperationContext.Current.GetCallbackChannel<IPubSubContract>();
            NameHandler = new NameChangeEventHandler(PublishNameChangeHandler);
            NameChangeEvent += NameHandler;

        }

        private void PublishNameChangeHandler(object sender, ServiceEventArgs e)
        {
            ServiceCallback.NameChange(e.Name);
        }

        public void Unsubscribe()
        {
            NameChangeEvent -= NameHandler;
        }

        
    }

    public class ServiceEventArgs : EventArgs
    {
        public string Name;
    }
}
