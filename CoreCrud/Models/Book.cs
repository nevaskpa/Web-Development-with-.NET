using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Book
    {
        public string ID { get; set; } // ID property for a book
        public string Title { get; set; }
        public string Author { get; set; }
        public int Edition { get; set; }
        public string YearPublished { get; set; }

        [DataType(DataType.Date)]
        public DateTime? LaunchDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public bool? IsBestseller { get; set; }

        // Defining the relationship
        public string BookPublisherId { get; set; }
        public Publisher Publisher { get; set; }
        
    }
}
