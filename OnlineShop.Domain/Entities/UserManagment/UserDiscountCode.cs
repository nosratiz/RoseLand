using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Domain.Entities.UserManagment
{
    public class UserDiscountCode
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int DiscountCodeId { get; set; }


        public virtual User User { get; set; }
        public virtual DiscountCode DiscountCode { get; set; }
    }
}