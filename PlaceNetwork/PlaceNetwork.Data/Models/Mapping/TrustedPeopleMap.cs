using System.Data.Entity.ModelConfiguration;

namespace PlaceNetwork.Data.Models.Mapping
{
    public class TrustedPeopleMap : EntityTypeConfiguration<TrustedPeople>
    {
        public TrustedPeopleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("TrustedPeoples");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.TrustedUserId).HasColumnName("TrustedUserId");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.TrustedPeoples)
                .HasForeignKey(d => d.UserId);
        }
    }
}
