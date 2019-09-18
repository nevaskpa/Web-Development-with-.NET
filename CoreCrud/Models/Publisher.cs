using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Publisher
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Country { get; set; }

        // Defining the relationship
        public ICollection<Book> Books { get; set; }

        public bool BestsellingProfile
        {
            get
            {   foreach (var item in Books)
                {
                    if (item.IsBestseller == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }
    }
}
