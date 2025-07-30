using LibraryManagement.Domain.ValueObjects;

namespace LibraryManagement.Domain.Entities
{

    //Rich Domain Model
    public class User
    {
        public UserId Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }


        //private constructor
        private User(UserId id, string name, string email, string passwordHash)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }

        //factory method to create a new user
        public static User Create(string name, string email, string passwordHash)
        {
            return new User(new UserId(Guid.NewGuid()), name, email, passwordHash);
        }

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
        }

        public void Update(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Name cannot be empty", nameof(newName));
            }
            Name = newName;
        }

    }
}
