namespace MLDev.AuthSystem.DTOs
{
    public class UserLoginResultDto
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public TokenDto Token { get; set; }
    }
}
