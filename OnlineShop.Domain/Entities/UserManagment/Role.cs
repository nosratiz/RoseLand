using System.Collections.Generic;

namespace OnlineShop.Domain.Entities.UserManagement
{
    public class Role
    {
        public static int Admin = 1;

        public static int User = 2;
        public Role()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; }
    }
}