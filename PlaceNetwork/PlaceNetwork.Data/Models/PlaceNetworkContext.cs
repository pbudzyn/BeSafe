using System.Data.Entity;
using PlaceNetwork.Data.Models.Mapping;

namespace PlaceNetwork.Data.Models
{
    public class PlaceNetworkContext : DbContext
    {
        static PlaceNetworkContext()
        {
            Database.SetInitializer<PlaceNetworkContext>(null);
        }

        public PlaceNetworkContext()
            : base("Name=PlaceNetworkContext")
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TrustedPeople> TrustedPeoples { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new PlaceMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new TrustedPeopleMap());
        }
    }
}
