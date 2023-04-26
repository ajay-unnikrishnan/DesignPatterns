using System;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*

    This class defines a Singleton pattern that allows only one instance of the class to exist in the application.
    To verify, It also includes a counter that tracks the number of times the instance is created.
    A private constructor will prevent the class from being inherited. 
    The class is marked as sealed to prevent it from being inherited in the nested class.
    As locking is costly, need to lock only at the time of initial object creation.`
    
    */
    public sealed class Singleton
    {
        public static int counter = 0;
        private static readonly object obj = new object();
        private static Singleton _instance = null;
        public static Singleton GetInstance
        {
            get
            {
                if (_instance == null) // Check if instance has already been created
                { 
                    lock (obj) // Lock the process to ensure thread safety
                    {
                        if (_instance == null) // double check locking
                        {
                            _instance = new Singleton();
                            counter++;
                        }
                    }
                }
                return _instance;
            }
        }
        public static Singleton GetInstance1
        {
            get
            {                
                if (_instance == null)
                {
                    _instance = new Singleton();
                    counter++;
                }                    
                return _instance;
            }
        }

        // The private constructor ensures that no new instances of the class can be created outside the class
        private Singleton()
        {

        }
        public void Print(string str)
        {
            Console.WriteLine(str);
        } 
    }
    public class ValidateSingleton
    {
        public void Validate()
        {
            // Validating the thread safety.
            Parallel.Invoke(
                () => F1(),
                () => F2()
                ); 
        }
        static void F1()
        {
            Singleton x = Singleton.GetInstance;
            x.Print("from object " + Singleton.counter);
        }
        static void F2()
        {
            Singleton x = Singleton.GetInstance;
            x.Print("from object " + Singleton.counter);
        }
    }
    
}
