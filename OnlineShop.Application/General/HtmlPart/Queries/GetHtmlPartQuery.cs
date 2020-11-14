using MediatR;
using OnlineShop.Application.General.HtmlPart.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.HtmlPart.Queries
{
    public class GetHtmlPartQuery : IRequest<Result<HtmlPartDto>>
    {
        public int Id { get; set; }
    }
}