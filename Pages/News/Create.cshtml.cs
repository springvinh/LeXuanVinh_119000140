using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LeXuanVinh.Models;

namespace LeXuanVinh.Pages_News
{
    public class CreateModel : PageModel
    {
        private readonly MyContext _context;

        public CreateModel(MyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Categories = _context.Category.ToList();

            return Page();
        }

        [BindProperty]
        public News News { get; set; }
        public IList<Category> Categories {get; set;}

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("dssdfsdgsd");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Console.WriteLine(News.Category.Name);

            _context.News.Add(News);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
