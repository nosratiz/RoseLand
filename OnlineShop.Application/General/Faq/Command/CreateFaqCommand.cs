using MediatR;
using OnlineShop.Application.General.Faq.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Faq.Command
{
    public class CreateFaqCommand : IRequest<Result<FaqDto>>
    {
        public string Answer { get; set; }
        public string Question { get; set; }
    }
}