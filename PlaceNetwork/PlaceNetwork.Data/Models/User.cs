using System;
using System.Collections.Generic;

namespace PlaceNetwork.Data.Models
{
    public class User
    {
        public User()
        {
            this.Comments = new List<Comment>();
            this.Places = new List<Place>();
            this.TrustedPeoples = new List<TrustedPeople>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateRegistered { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<TrustedPeople> TrustedPeoples { get; set; }
    }
}
