﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Data.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<FeedBack> FeedBacks { get; set; }
        public ProfileUser ProfileUser { get; set; }
    }
}
