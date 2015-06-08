using System.Data.Entity.ModelConfiguration;

namespace PlaceNetwork.Data.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Comments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.TimePosted).HasColumnName("TimePosted");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.PlaceId).HasColumnName("PlaceId");

            // Relationships
            this.HasRequired(t => t.Place)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.PlaceId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.UserId);

        }
    }
}
