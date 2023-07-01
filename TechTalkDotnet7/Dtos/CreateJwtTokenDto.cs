namespace TechTalkDotnet7.Dtos
{
    public class CreateJwtTokenDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public List<string> UserRoles { get; set; } = new List<string>();
    }
}
