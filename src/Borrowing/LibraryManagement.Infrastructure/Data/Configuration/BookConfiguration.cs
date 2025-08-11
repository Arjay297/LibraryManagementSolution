using Borrowing.Domain.Entities;
using Borrowing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Borrowing.Infrastructure.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> book)
        {
            book.HasKey(u => u.Id);
            book.Property(u => u.Id)
                .HasConversion(u => u.Value, value => new BookId(value));
        }
    }
}
