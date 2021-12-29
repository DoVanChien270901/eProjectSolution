using ArtGallery.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Data.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public Roleposition Position { get; set; }
        public List<Account> Admin { get; set; }
    }
}
