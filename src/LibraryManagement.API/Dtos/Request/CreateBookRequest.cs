using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.API.Dtos.Request
{
    public class CreateBookRequest
    {
        [Required]
        public string Title { get; set; } = null!;
    }
}
