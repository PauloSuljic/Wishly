namespace UserService.Models
{
    public class User
    {
        public int Id { get; set; } // Primary Key
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
