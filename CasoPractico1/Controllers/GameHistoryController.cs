using CasoPractico1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CasoPractico1.Controllers
{
    public class GameHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var gameHistories = await _context.GameResults
                .Select(gr => new GameHistoryViewModel
                {
                    Username = gr.User.FullName,
                    Score = gr.Score,
                    Duration = gr.Duration,
                    DatePlayed = gr.Date
                })
                .ToListAsync();

            return View(gameHistories);
        }
    }
}
