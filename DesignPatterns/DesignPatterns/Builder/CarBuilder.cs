using System;

namespace DesignPatterns.Builder
{
    public class Director
    {
        public void Debug()
        {
            var builder = new CarBuilder();
            Car obj = builder.SetColor("Red")
                .SetMake("Ford")
                .SetManufactureDate(DateTime.Now)
                .Build();
        }
    }

    public class CarBuilder : ICarBuilder
    {
        Car _car = new Car();
        public ICarBuilder SetColor(string color)
        {
            _car.Color = color;
            return this;
        }

        public ICarBuilder SetMake(string make)
        {
            _car.Make = make;
            return this;
        }

        public ICarBuilder SetManufactureDate(DateTime date)
        {
            _car.ManuifactureDate = date.ToString();
            return this;
        }
        public Car Build() => _car;
    }
    public class Car
    {
        public string Make { get; set; }
        public string Color { get; set; }
        public string ManuifactureDate { get; set; }
    }
    public interface ICarBuilder
    {
        ICarBuilder SetMake(string make);
        ICarBuilder SetColor(string color);
        ICarBuilder SetManufactureDate(DateTime date);
        Car Build();
    }
}
