using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Publisher
    {
        public int ID { get; set; } 

        [Required]
        public string Name { get; set; }
        public string Country { get; set; }

        // Defining the relationship
        public ICollection<Book> Books { get; set; }

        public bool BestsellingProfile
        {
            get
            {
                if (Books == null)
                    return false;
                else
                {
                    foreach (var item in Books)
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
                }
                return false;
            }
        }
    }
}
