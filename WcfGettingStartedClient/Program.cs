using System;
using System.ServiceModel;
using WcfGettingStartedClient.CalculatorServiceReference;

namespace WcfGettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Create an instance of the WCF proxy.
            InstanceContext instanceContext = new InstanceContext(new CalculatorServiceCallbackHandler());
            CalculatorClient client = new CalculatorClient(instanceContext);

            // Step 2: Call the service operations.
            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            client.Add(value1, value2);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            client.Subtract(value1, value2);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            client.Multiply(value1, value2);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            client.Divide(value1, value2);

            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            //Step 3: Closing the client gracefully closes the connection and cleans up resources.
            client.Close();
        }
    }

    internal class CalculatorServiceCallbackHandler : ICalculatorCallback
    {
        public CalculatorServiceCallbackHandler()
        {
        }

        public void Equals(string equation, double result)
        {
            Console.WriteLine($"{equation} = {result}");
        }
    }
}
