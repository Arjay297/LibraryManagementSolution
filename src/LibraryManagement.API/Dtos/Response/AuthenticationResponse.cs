namespace LibraryManagement.API.Dtos.Response
{
    public class AuthenticationResponse
    {
        public bool IsSuccess { get; set; }
        public string? AccessToken { get; set; }
        public string? Message { get; set; }
    }
}
