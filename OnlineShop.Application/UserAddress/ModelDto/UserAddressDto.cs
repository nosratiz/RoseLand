using OnlineShop.Application.Users.ModelDto;

namespace OnlineShop.Application.UserAddress.ModelDto
{
    public class UserAddressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual UserDto User { get; set; }
    }
}