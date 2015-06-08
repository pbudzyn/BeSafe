using System.Collections.Generic;
using PlaceNetwork.Data.Models;

namespace PlaceNetwork.BusinessLogic.Services.Interfaces
{
    public interface IPlaceService
    {
        Place Add(Place place);
        void Delete(int id);
        void Update(Place place);
        Place GetById(int id);
        List<Place> GetByUserId(int userId);
        List<Place> GetAll();
    }
}