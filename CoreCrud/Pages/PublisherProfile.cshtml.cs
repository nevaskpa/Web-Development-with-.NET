using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class PublisherProfileModel : PageModel
    {
        private AppDbContext _context;
        public PublisherProfileModel(AppDbContext context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher = _context.Publishers.Include(pub => pub.Books)
                                           .FirstOrDefault(x => x.ID == id);
            if (Publisher == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}