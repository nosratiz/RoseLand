namespace OnlineShop.UI.Core
{
    public interface IRequestMeta
    {
        string Ip { get; set; }
        string UserAgent { get; set; }
        string Browser { get; set; }
        string Os { get; set; }
        string Device { get; set; }
    }
}