using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfGettingStartedLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CalculatorService : ICalculator
    {
        ICalculatorCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ICalculatorCallback>();
            }
        }

        public void Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine($"Received Add({n1},{n2})");
            Console.WriteLine($"Return: {result}");
            Callback.Equals($"Add({n1},{n2})", result);
        }

        public void Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine($"Received Subtract({n1},{n2})");
            Console.WriteLine($"Return: {result}");
            Callback.Equals($"Subtract({n1},{n2})", result);
        }

        public void Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine($"Received Multiply({n1},{n2})");
            Console.WriteLine($"Return: {result}");
            Callback.Equals($"Multiply({n1},{n2})", result);
        }

        public void Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine($"Received Divide({n1},{n2})");
            Console.WriteLine($"Return: {result}");
            Callback.Equals($"Divide({n1},{n2})", result);
        }
    }
}
