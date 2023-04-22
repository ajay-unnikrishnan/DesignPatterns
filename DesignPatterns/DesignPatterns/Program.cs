using System;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new ValidateSingleton().Validate();
            new ValidateDecorator();
        }
        

    }
}
