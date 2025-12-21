namespace QuestionPlatform2.ViewModels
{
    public class UserRoleModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public List<string> Roles { get; set; } = new();
        public List<string> AllRoles { get; set; } = new();
    }
}
