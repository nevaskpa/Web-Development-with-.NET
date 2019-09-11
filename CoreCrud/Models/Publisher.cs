using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Publisher
    {
        public string ID { get; set; } 
        public string Name { get; set; }
        public string Country { get; set; }

        // Defining the relationship
        public ICollection<Book> Books { get; set; }
    }
}
