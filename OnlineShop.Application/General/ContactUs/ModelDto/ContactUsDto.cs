using System;

namespace OnlineShop.Application.General.ContactUs.ModelDto
{
    public class ContactUsDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
    }
}