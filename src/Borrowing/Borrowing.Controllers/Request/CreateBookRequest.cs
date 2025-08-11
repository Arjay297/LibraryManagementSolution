using System.ComponentModel.DataAnnotations;

namespace Borrowing.Controllers.Request
{
    public class CreateBookRequest
    {
        [Required]
        public string Title { get; set; } = null!;
    }
}
