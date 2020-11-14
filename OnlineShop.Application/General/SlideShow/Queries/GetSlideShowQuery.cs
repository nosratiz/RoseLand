using MediatR;
using OnlineShop.Application.General.SlideShow.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.SlideShow.Queries
{
    public class GetSlideShowQuery : IRequest<Result<SlideShowDto>>
    {
        public int Id { get; set; }
    }

}