using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LeXuanVinh.Models;

namespace LeXuanVinh.Pages_News
{
    public class DetailsModel : PageModel
    {
        private readonly MyContext _context;

        public DetailsModel(MyContext context)
        {
            _context = context;
        }
        
        public News News { get; set; }
        [BindProperty]
        public IList<Comment> Comments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            News = await _context.News.FirstOrDefaultAsync(m => m.ID == id);
            
            if (News.Comments != null) {
                foreach (var item in News.Comments)
                {
                    Comments.Add(await _context.Comment.FirstOrDefaultAsync(m => m.ID == item.ID));
                }
            }

            if (News == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}
