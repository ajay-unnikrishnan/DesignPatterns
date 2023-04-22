using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class ValidateDecorator
    {
        public ValidateDecorator()
        {
            ICar car = new Ford();

            // Decorate the Ford car with a new year offer
            CarDecorator decorator = new FordNewyearOffer(car);

            Console.WriteLine(string.Format("Make:{0}, Price:{1}, Discount Price:{2}", 
                decorator.Make, decorator.GetPrice(), decorator.GetDiscountedPrice()));            
        }
    }
    public interface ICar
    {
        string Make { get; }
        double GetPrice();
    }
    public sealed class Ford : ICar
    {
        public string Make
        {
            get { return "Mustang"; }
            
        }

        public double GetPrice()
        {
            return 10000;
        }        
    }
    /* 
     * Abstract decorator class that implements the ICar interface and serves as a base class for all car decorator classes
     */
    public abstract class CarDecorator : ICar
    {        
        private ICar _car;
        public CarDecorator(ICar car)
        {
            _car = car;
        }
        public string Make { get { return _car.Make;  } }
        public double GetPrice()
        {
            return _car.GetPrice();
        }
        public abstract double GetDiscountedPrice();
    }
    /*
     * Concrete decorator class that extends the behavior of a Ford car by offering a new year discount     
     */
    public class FordNewyearOffer : CarDecorator
    {
        public FordNewyearOffer(ICar car): base(car) { }
        public override double GetDiscountedPrice()
        {
            return 0.9 * base.GetPrice();
        }
    }
}
