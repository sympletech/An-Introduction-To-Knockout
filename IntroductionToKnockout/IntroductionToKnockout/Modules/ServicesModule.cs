using IntroductionToKnockout.Data;
using Nancy;
using Nancy.ModelBinding;
using System.Linq;

namespace IntroductionToKnockout.Modules
{
    public class ServicesModule : NancyModule 
    {
        public ServicesModule() : base("/Services")
        {
            Get["/Cars"] = ctx => FakeDatabase.Cars;

            Post["/Cars"] = ctx =>
                {
                    var carToAdd = this.Bind<Car>();
                    if (carToAdd.Id == null)
                    {
                        try
                        {
                            carToAdd.Id = FakeDatabase.Cars.Select(x => x.Id).Max() + 1;
                        }
                        catch
                        {
                            carToAdd.Id = 1;
                        }
                        FakeDatabase.Cars.Add(carToAdd);
                    }
                    else
                    {
                        var carToUpdate = FakeDatabase.Cars.Find(x => x.Id == carToAdd.Id);
                        var i = FakeDatabase.Cars.IndexOf(carToUpdate);
                        FakeDatabase.Cars[i] = carToAdd;
                    }

                    return FakeDatabase.Cars;
                };

            Delete["/Cars/{id}"] = ctx =>
                {
                    var id = ctx["id"];
                    var itemToDelete = FakeDatabase.Cars.Find(x => x.Id == id);
                    FakeDatabase.Cars.Remove(itemToDelete);

                    return FakeDatabase.Cars;
                };
        }


    }
}