using System.ComponentModel.DataAnnotations;

namespace PlaceNetwork.Models
{
    public class PlaceModel
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }
    }
}
