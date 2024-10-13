namespace FumLabAPI.Contracts.User
{
    public class GetUserResponse
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
