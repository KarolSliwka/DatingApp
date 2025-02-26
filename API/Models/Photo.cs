using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }

        // Navigation properties - required one to many relationship
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;

    }
}