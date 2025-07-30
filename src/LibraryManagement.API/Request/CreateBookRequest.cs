using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.API.Request
{
    public class CreateBookRequest
    {
        [Required]
        public string Title { get; set; } = null!;
    }
}
