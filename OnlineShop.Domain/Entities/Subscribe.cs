namespace OnlineShop.Domain.Entities
{
    public class Subscribe
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}