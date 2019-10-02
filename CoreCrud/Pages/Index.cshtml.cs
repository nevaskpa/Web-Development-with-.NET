using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreCrud.Pages
{
    public class IndexModel : PageModel
    {
        private AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public int CountOfBestsellers { get; set; }
        public int CountOfPublishers { get; set; }
        public int CountOfGenres { get; set; }
        public int CountOfClassics { get; set; }
        
        public void OnGet()
        {
            CountOfBestsellers = _context.Books.Count(x => x.IsBestseller == true);
            CountOfPublishers = _context.Publishers.Count();
            CountOfGenres = _context.Books.GroupBy(x => x.Genre).Count();
            CountOfClassics = _context.Books.Count(x => x.IsClassic == true);
        }
    }
}
