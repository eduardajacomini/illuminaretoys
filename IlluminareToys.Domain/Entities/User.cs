using Microsoft.AspNetCore.Identity;

namespace IlluminareToys.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int UsernameChangeLimit { get; set; } = 10;

        public byte[] ProfilePicture { get; set; }
    }
}
