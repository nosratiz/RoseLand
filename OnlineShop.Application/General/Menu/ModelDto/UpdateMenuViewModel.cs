using System.Collections.Generic;
using OnlineShop.Application.General.Menu.Command.UpdateMenu;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Menu.ModelDto
{
    public class UpdateMenuViewModel
    {
        public List<MenuDto> MenuList { get; set; }

        public Result<MenuDto> MenResult { get; set; }


        public static UpdateMenuViewModel GetUpdateMenuViewModel(Result<MenuDto> menuResult, List<MenuDto> MenuList)
            => new UpdateMenuViewModel
            {
                MenuList = MenuList,
                MenResult = menuResult
            };
    }
}