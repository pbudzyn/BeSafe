using System.Collections.Generic;
using System.Linq;
using PlaceNetwork.BusinessLogic.Repositories;
using PlaceNetwork.BusinessLogic.Services.Interfaces;
using PlaceNetwork.Data.Models;

namespace PlaceNetwork.BusinessLogic.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWorkFactory _factory;

        public PlaceService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public Place Add(Place place)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                if (place == null) return null;
                var result = unitOfWork.PlaceRepository.Insert(place);
                unitOfWork.Save();
                return result;
            }
        }

        public void Delete(int id)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                unitOfWork.PlaceRepository.Delete(id);
                unitOfWork.Save();
            }
        }

        public void Update(Place place)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                unitOfWork.PlaceRepository.Update(place);
                unitOfWork.Save();
            }
        }

        public Place GetById(int id)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.PlaceRepository.GetById(id);
            }
        }

        public List<Place> GetByUserId(int userId)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.PlaceRepository.Get(x => x.UserAddedId == userId).ToList();
            }
        }

        public List<Place> GetAll()
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.PlaceRepository.Get().ToList();
            }
        }
    }
}
