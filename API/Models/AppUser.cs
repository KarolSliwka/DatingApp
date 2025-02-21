namespace API.Models
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; } = string.Empty;
    }
}