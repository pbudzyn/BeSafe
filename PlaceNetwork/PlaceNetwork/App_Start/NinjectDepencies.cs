using Ninject;
using PlaceNetwork.BusinessLogic.Repositories;
using PlaceNetwork.BusinessLogic.Services;
using PlaceNetwork.BusinessLogic.Services.Interfaces;

namespace PlaceNetwork
{
    static class NinjectDepencies
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IPlaceService>().To<PlaceService>();
            kernel.Bind<ITrustedPeopleService>().To<TrustedPeopleService>();
        }
    }
}
