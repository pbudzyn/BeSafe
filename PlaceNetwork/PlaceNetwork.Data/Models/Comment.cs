using System;

namespace PlaceNetwork.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime TimePosted { get; set; }
        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
        public virtual User User { get; set; }
    }
}
