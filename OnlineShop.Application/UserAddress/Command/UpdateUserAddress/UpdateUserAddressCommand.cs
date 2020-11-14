using MediatR;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.UserAddress.Command.UpdateUserAddress
{
    public class UpdateUserAddressCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}