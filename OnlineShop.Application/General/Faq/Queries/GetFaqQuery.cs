using MediatR;
using OnlineShop.Application.General.Faq.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Faq.Queries
{
    public class GetFaqQuery : IRequest<Result<FaqDto>>
    {
        public long Id { get; set; }
    }
}