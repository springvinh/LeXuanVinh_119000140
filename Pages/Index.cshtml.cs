using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LeXuanVinh.Pages;

public class IndexModel : PageModel
{
    // private readonly ILogger<IndexModel> _logger;

    // public IndexModel(ILogger<IndexModel> logger)
    // {
    //     _logger = logger;
    // }

    private readonly MyContext _context;

    public IndexModel(MyContext context)
    {
        _context = context;
    }

    public IList<LeXuanVinh.Models.News> News { get; set; }

    public async Task OnGetAsync()
    {
        News = await _context.News.ToListAsync();
    }

}
