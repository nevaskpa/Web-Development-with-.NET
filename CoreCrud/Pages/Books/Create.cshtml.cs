﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreCrud.Models;

namespace CoreCrud.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly CoreCrud.Models.AppDbContext _context;

        public CreateModel(CoreCrud.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["PublisherId"] = new SelectList(_context.Publishers, "ID", "Name");
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}