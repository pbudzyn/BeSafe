using System.Data.Entity.ModelConfiguration;

namespace PlaceNetwork.Data.Models.Mapping
{
    public class PlaceMap : EntityTypeConfiguration<Place>
    {
        public PlaceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(2000);

            this.Property(t => t.Latitude)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Longitude)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Places");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.LikeNumber).HasColumnName("LikeNumber");
            this.Property(t => t.DislikeNumber).HasColumnName("DislikeNumber");
            this.Property(t => t.UserAddedId).HasColumnName("UserAddedId");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.Places)
                .HasForeignKey(d => d.UserAddedId);

        }
    }
}
