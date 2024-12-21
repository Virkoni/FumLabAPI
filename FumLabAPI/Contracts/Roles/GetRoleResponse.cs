namespace FumLabAPI.Contracts.Roles
{
    public class GetRoleResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}