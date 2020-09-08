using HotelWebApi.Models;
using HotelWebApi.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace HotelWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<IRepository<Branch>, BranchRepository>();
            container.RegisterType<IRepository<Room>, RoomRepository>();
            container.RegisterType<IRepository<Booking>, BookingRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}