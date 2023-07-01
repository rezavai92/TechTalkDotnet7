namespace TechTalkDotnet7.Dtos
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }  
        public string Language { get; set; }
    }
}
