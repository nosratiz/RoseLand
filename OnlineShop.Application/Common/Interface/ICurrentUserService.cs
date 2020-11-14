namespace OnlineShop.Application.Common.Interface
{
    public interface ICurrentUserService
    {
        string UserId { get;  }

        bool IsAuthenticated { get; }
    }
}