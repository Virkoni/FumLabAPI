namespace PetShopAPI.Contracts.User
{
    public class CreateUserRequest
    {

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Email { get; set; } = null!;

    }
}
