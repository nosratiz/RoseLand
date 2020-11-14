using MediatR;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.HtmlPart.Command.UpdateHtmlPart
{
    public class UpdateHtmlPartCommand : IRequest<Result>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string UniqueName { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public bool IsPublished { get; set; }

    }
}