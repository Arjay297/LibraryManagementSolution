using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.API.Data.Models
{
    public class Member
    {
        public Guid Id { get; set; }

        [MaxLength(500)]
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int MaxBook { get; set; }

        public List<Book> BorrowedBooks { get; set; }
    }
}
