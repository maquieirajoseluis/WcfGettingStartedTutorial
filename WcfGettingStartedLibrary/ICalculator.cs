using System.ServiceModel;

namespace WcfGettingStartedLibrary
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICalculatorCallback))]
    public interface ICalculator
    {
        [OperationContract(IsOneWay = true)]
        void Add(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Subtract(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Multiply(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Divide(double n1, double n2);
    }

    public interface ICalculatorCallback
    {
        [OperationContract(IsOneWay = true)]
        void Equals(string equation, double result);
    }
}
