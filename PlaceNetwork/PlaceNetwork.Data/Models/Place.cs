using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PlaceNetwork.Data.Models
{
    [DataContract]
    public class Place
    {
        public Place()
        {
            this.Comments = new List<Comment>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int? CategoryId { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public long LikeNumber { get; set; }
        [DataMember]
        public long DislikeNumber { get; set; }
        [DataMember]
        public int? UserAddedId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual User User { get; set; }
    }
}
