using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
               
                Console.WriteLine("\n{0}\n", "Test");
                string message = string.Empty;
                using (PubSubServiceHost host = new PubSubServiceHost())
                {
                    host.Start();


                    message = "Press <Enter> to change name.";
                   

                    Console.WriteLine(message);

                    Console.ReadLine();

                    host.ChangeName("Marko");

                    Console.WriteLine("Press <Enter> to end");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("PubSub Service failed.");
                Console.WriteLine(ex.StackTrace);
               
                Console.ReadLine();
            }
        }
    }
}
