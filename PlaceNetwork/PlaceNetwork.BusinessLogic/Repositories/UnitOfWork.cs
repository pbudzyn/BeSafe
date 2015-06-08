using System;
using PlaceNetwork.Data.Models;

namespace PlaceNetwork.BusinessLogic.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly PlaceNetworkContext _context = new PlaceNetworkContext();

        public IGenericRepository<User> _userRepository = null;
        public IGenericRepository<Place> _placeRepository = null;
        public IGenericRepository<Comment> _commentRepository = null;
        public IGenericRepository<TrustedPeople> _trustedPeopleRepository = null;

        public IGenericRepository<User> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new GenericRepository<User>(_context)); }
        }

        public IGenericRepository<Place> PlaceRepository
        {
            get { return _placeRepository ?? (_placeRepository = new GenericRepository<Place>(_context)); }
        }

        public IGenericRepository<Comment> CommentRepository
        {
            get { return _commentRepository ?? (_commentRepository = new GenericRepository<Comment>(_context)); }
        }

        public IGenericRepository<TrustedPeople> TrustedPeopleRepository
        {
            get { return _trustedPeopleRepository ?? (_trustedPeopleRepository = new GenericRepository<TrustedPeople>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
    }
}
