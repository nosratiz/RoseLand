﻿using System;

namespace OnlineShop.Domain.Entities
{
    public class ContactUs
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
    }
}