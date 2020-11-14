using MediatR;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.SlideShow.Command.DeleteSlideShow
{
    public class DeleteSlideShowCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}