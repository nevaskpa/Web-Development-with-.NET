using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Book
    {
        public int ID { get; set; } // ID property for a book
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
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public bool IsClassic
        {
            get
            {
                int year = Int32.Parse(YearPublished);

                if (year <= 1990)
                    return true;

                else
                    return false;
            }
        }
    }
}
