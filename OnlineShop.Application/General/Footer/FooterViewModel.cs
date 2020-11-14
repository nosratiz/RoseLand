using OnlineShop.Application.General.AppSetting.ModelDto;

namespace OnlineShop.Application.General.Footer
{
    public class FooterViewModel
    {
        public AppSettingDto AppSetting { get; set; }

        public static FooterViewModel GetFooterViewModel(AppSettingDto appSetting) => new FooterViewModel
        {
            AppSetting = appSetting
        };
    }
}