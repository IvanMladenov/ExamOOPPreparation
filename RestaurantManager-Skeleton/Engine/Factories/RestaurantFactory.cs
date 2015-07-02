namespace RestaurantManager.Engine.Factories
{
    using RestaurantManager.Interfaces;
    using RestaurantManager.Interfaces.Engine;
    using RestaurantManager.Models;

    public class RestaurantFactory : IRestaurantFactory
    {
        public IRestaurant CreateRestaurant(string name, string location)
        {
            return new Restarurant(name, location);
        }
    }
}