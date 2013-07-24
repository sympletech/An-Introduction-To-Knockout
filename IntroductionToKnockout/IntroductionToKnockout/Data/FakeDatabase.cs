using System.Collections.Generic;

namespace IntroductionToKnockout.Data
{
    public static class FakeDatabase
    {
        private static List<Car> _cars;
        public static List<Car> Cars
        {
            get { 
                return _cars ?? (_cars = new List<Car>
                {
                    new Car{Id = 1,Name = "Pontiac GTO", Speed = "250", Type = "Car"},
                    new Car{Id = 2,Name = "Infinity G37", Speed = "180", Type = "Car"},
                    new Car{Id = 3,Name = "Honda Civic", Speed = "140", Type = "Car"},
                    new Car{Id = 3,Name = "Ford F150", Speed = "80", Type = "Truck"},
                    new Car{Id = 3,Name = "Dodge RAM", Speed = "75", Type = "Truck"}
                }); 
            }
            set { _cars = value; }
        } 
    }
}