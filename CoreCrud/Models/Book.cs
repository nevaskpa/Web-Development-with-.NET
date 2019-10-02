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
        [Required]
        [CustomValidation(typeof(Book), "TitleIsUnique")]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public int Edition { get; set; }

        [RegularExpression(@"[1-2][0-9][0-9][0-9]", ErrorMessage ="Please Enter a Valid Year (YYYY)")]
        [Display(Name = "Year of Publication")]
        public string YearPublished { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Launch Date")]
        [CustomValidation(typeof(Book), "LaunchDateInPast")]
        public DateTime? LaunchDate { get; set; }

        [StringLength(20)]
        public string Genre { get; set; }

        [Range(0, 100.00)]
        public decimal Price { get; set; }

        [Display(Name = "Bestseller")]
        public bool? IsBestseller { get; set; }

        // Defining the relationship
        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public bool? IsClassic
        {
            get
            {
               if (YearPublished == null)
                    return false;

                else
                {
                    int year = Int32.Parse(YearPublished);

                    if (year <= 1990)
                        return true;

                    else
                        return false;
                }
            }
        }


        public static ValidationResult TitleIsUnique(string title, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return ValidationResult.Success;
            }

            var instance = context.ObjectInstance as Book;

            if (instance == null)
            {
                return ValidationResult.Success;
            }
           
            var dbContext = context.GetService(typeof(AppDbContext)) as AppDbContext;
           
            int duplicateCount = dbContext.Books
                                          .Count(x => x.ID != instance.ID && x.Title == title);

            if (duplicateCount > 0)
            {
                return new ValidationResult($"{title} already exists!!");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult LaunchDateInPast(DateTime? launchDate, ValidationContext context)
        {
            if (launchDate == null)
            {
                return ValidationResult.Success;
            }
            
            if (launchDate <= DateTime.Today)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Launch Date can not be in the future.");
        }
    }
}
