using System.Collections.Generic;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Domain.Entities.Shop
{
    public class UserAddress
    {

        public UserAddress()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public bool IsDeleted { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Order> Orders { get; }
    }
}