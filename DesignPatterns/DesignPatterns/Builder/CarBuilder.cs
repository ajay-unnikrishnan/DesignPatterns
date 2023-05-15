using System;

namespace DesignPatterns.Builder
{
    /// <summary>
    /// The Director controls the construction process using a builder object.
    /// </summary>
    public class Director
    {
        /// <summary>
        /// Builds a car using a specific builder.
        /// </summary>
        public void BuildCar()
        {
            var builder = new CarBuilder();
            Car obj = builder.SetColor("Red")
                .SetMake("Ford")
                .SetManufactureDate(DateTime.Now)
                .Build();
        }
    }
    public class Car
    {
        public string Make { get; set; }
        public string Color { get; set; }
        public string ManuifactureDate { get; set; }
    }
    /// <summary>
    /// Defines the interface for building the product
    /// </summary>
    public interface ICarBuilder
    {
        ICarBuilder SetMake(string make);
        ICarBuilder SetColor(string color);
        ICarBuilder SetManufactureDate(DateTime date);
        Car Build();
    }
    /// <summary>
    /// The CarBuilder  is responsible for constructing and assembling the parts of the Car object.
    /// </summary>
    public class CarBuilder : ICarBuilder
    {
        Car _car = new Car();

        /// <summary>
        /// Sets the color of the car.
        /// </summary>
        public ICarBuilder SetColor(string color)
        {
            _car.Color = color;
            return this;
        }
        /// <summary>
        /// Sets the make of the car.
        /// </summary>
        public ICarBuilder SetMake(string make)
        {
            _car.Make = make;
            return this;
        }
        /// <summary>
        /// Sets the manufacture date of the car.
        /// </summary>
        public ICarBuilder SetManufactureDate(DateTime date)
        {
            _car.ManuifactureDate = date.ToString();
            return this;
        }
        /// <summary>
        /// Builds and returns the car object.
        /// </summary>
        public Car Build() => _car;
    }
    
}
