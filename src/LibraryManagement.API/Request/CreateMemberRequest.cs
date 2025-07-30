using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.API.Request
{
    public class CreateMemberRequest
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
