using MediatR;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.UserAddress.Command.DeleteUserAddress
{
    public class DeleteUserAddressCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}