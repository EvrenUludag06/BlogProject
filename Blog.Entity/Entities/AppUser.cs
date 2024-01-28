using Microsoft.AspNetCore.Identity;
using Blog.Core.Entities;

namespace Blog.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>, IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid ImageId { get; set; } = Guid.Parse("4084c97a-2aa1-4675-b519-69f6fe410633");
        public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
