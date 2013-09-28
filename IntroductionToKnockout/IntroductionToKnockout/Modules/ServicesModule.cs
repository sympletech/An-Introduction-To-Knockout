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

            Get["/Cars/{id}"] = ctx =>
                {
                    var id = ctx["id"];
                    return FakeDatabase.Cars.Find(x => x.Id == id);                    
                };

            Post["/Cars"] = ctx =>
                {
                    object result; 

                    var carToAdd = this.Bind<Car>();
                    if (carToAdd.Id == null || carToAdd.Id == 0)
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
                        result = new
                        {
                            title = "New Vehicle Added",
                            body = "A New Vehicle Was Added"
                        };

                    }
                    else
                    {
                        var carToUpdate = FakeDatabase.Cars.Find(x => x.Id == carToAdd.Id);
                        var i = FakeDatabase.Cars.IndexOf(carToUpdate);
                        FakeDatabase.Cars[i] = carToAdd;
                        
                        result = new
                        {
                            title = "Existing Vehicle Updated",
                            body = "The Vehicle with PK " + carToAdd.Id + " Was Updated"
                        };
                    }

                    return result;
                };

            Delete["/Cars/{id}"] = ctx =>
                {
                    var id = ctx["id"];
                    var itemToDelete = FakeDatabase.Cars.Find(x => x.Id == id);
                    FakeDatabase.Cars.Remove(itemToDelete);

                    return new
                    {
                        title = "Vehicle Was Deleted",
                        body = "The Vehicle with PK " + id + " Was Deleted"
                    };
                };
        }


    }
}