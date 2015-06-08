using System;
using PlaceNetwork.Data.Models;

namespace PlaceNetwork.BusinessLogic.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Place> PlaceRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<TrustedPeople> TrustedPeopleRepository { get; }
        void Save();
    }
}