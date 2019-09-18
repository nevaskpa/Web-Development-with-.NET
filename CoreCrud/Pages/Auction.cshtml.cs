using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreCrud.Models;

namespace CoreCrud.Pages
{
    public class AuctionModel : PageModel
    {
        private AppDbContext _context;
        public AuctionModel(AppDbContext context) 
        {
            _context = context;
        }

        public ICollection<Book> Books { get; set; }
        public void OnGet()
        {
            Books = _context.Books.OrderBy(x => x.Title).ToList();
        }
    }
}