using PlaceNetwork.BusinessLogic.Repositories;
using PlaceNetwork.BusinessLogic.Services.Interfaces;
using PlaceNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceNetwork.BusinessLogic.Services
{
    public class TrustedPeopleService : ITrustedPeopleService
    {
        private readonly IUnitOfWorkFactory _factory;

        public TrustedPeopleService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public TrustedPeople Add(TrustedPeople trustedPeople)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                if (trustedPeople == null) return null;
                var result = unitOfWork.TrustedPeopleRepository.Insert(trustedPeople);
                unitOfWork.Save();
                return result;
            }
        }

        public void Delete(int id)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                unitOfWork.TrustedPeopleRepository.Delete(id);
                unitOfWork.Save();
            }
        }

        public void Update(TrustedPeople trustedPeople)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                unitOfWork.TrustedPeopleRepository.Update(trustedPeople);
                unitOfWork.Save();
            }
        }

        public TrustedPeople GetById(int id)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.TrustedPeopleRepository.GetById(id);
            }
        }

        public List<TrustedPeople> GetByUserId(int userId)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.TrustedPeopleRepository.Get(x => x.UserId == userId).ToList();
            }
        }

        public List<TrustedPeople> GetByTrustedUserId(int trustedUserId)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.TrustedPeopleRepository.Get(x => x.TrustedUserId == trustedUserId).ToList();
            }
        }

        public List<TrustedPeople> GetAll()
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.TrustedPeopleRepository.Get().ToList();
            }
        }
    }
}
