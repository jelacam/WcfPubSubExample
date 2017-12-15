using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService
{
    public class PubSubServiceHost : IDisposable
    {
        /// <summary>
		/// Instance of SCADA Collecting logic
		/// </summary>
		private Service pubsubService = null;

        /// <summary>
        /// ServiceHost list
        /// </summary>
        private List<ServiceHost> hosts = null;



        /// <summary>
        /// Initializes a new instance of the <see cref="SCADACollectingService"/> class
        /// Creates new SCADACollecting instance and initialize hosts
        /// </summary>
        public PubSubServiceHost()
        {
            this.pubsubService = new Service();
            this.InitializeHosts();
        }

        /// <summary>
        /// Starting hosts
        /// </summary>
        public void Start()
        {
            this.StartHosts();
        }

    

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            this.CloseHosts();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Initialize service hosts
        /// </summary>
        private void InitializeHosts()
        {
            this.hosts = new List<ServiceHost>();
            this.hosts.Add(new ServiceHost(typeof(Service)));
        }

        /// <summary>
        /// Starting hosts
        /// </summary>
        private void StartHosts()
        {
            if (this.hosts == null || this.hosts.Count == 0)
            {
                throw new Exception("PubSub Services can not be opened because it is not initialized.");
            }

            string message = string.Empty;
            foreach (ServiceHost host in this.hosts)
            {
                try
                {
                    host.Open();

                    message = string.Format("The WCF service {0} is ready.", host.Description.Name);
                    Console.WriteLine(message);
                    

                    foreach (Uri uri in host.BaseAddresses)
                    {
                        Console.WriteLine(uri);
                        
                    }

                    Console.WriteLine("\n");
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine(ce.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            
           

            message = "The PubSub Service is started.";
            Console.WriteLine("\n{0}", message);
           
        }

        public void ChangeName(string name)
        {
            pubsubService.PublishNameChange(name);
        }

        /// <summary>
        /// Closing hosts
        /// </summary>
        private void CloseHosts()
        {
            if (this.hosts == null || this.hosts.Count == 0)
            {
                throw new Exception("PubSub Services can not be closed because it is not initialized.");
            }

            foreach (ServiceHost host in this.hosts)
            {
                host.Close();
            }

            string message = "The PubSub Service is closed.";
            
            Console.WriteLine("\n\n{0}", message);
        }
    }
}
