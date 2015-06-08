using PlaceNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceNetwork.BusinessLogic.Services.Interfaces
{
    public interface ITrustedPeopleService
    {
        TrustedPeople Add(TrustedPeople trustedPeople);
        void Delete(int id);
        void Update(TrustedPeople trustedPeople);
        TrustedPeople GetById(int id);
        List<TrustedPeople> GetByUserId(int userId);
        List<TrustedPeople> GetAll();
        List<TrustedPeople> GetByTrustedUserId(int trustedUserId);
    }
}
