using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Exceptions
{
    public class BookAlreadyBorrowedException(string message) : DomainException(message)
    {
    }
}
