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
        public string Position { get; set; }
        public List<Admin> Admin { get; set; }
        
    }
}
