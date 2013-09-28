using Nancy;

namespace IntroductionToKnockout.Modules
{
    public class BaseRoutes : NancyModule
    {
        public BaseRoutes()
        {
            Get["/"] = ctx => View["Home/index"];
            Get["/Basics"] = ctx => View["Basics/Index"];
            Get["/Collections"] = ctx => View["Collections/Index"];
            Get["/Services"] = ctx => View["Services/Index"];
            Get["/Templates"] = ctx => View["Templates/Index"];
            Get["/Mapping"] = ctx => View["Mapping/Index"];
            Get["/PubSub"] = ctx => View["PubSub/Index"];
            Get["/UiUx"] = ctx => View["UiUx/Index"];

            
            Get["/Izzy"] = ctx => View["Izzy/Index"];
        }
    }
}