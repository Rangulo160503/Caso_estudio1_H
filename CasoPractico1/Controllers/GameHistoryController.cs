using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CasoPractico1.Data;
using CasoPractico1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CasoPractico1.Controllers
{
    [Authorize]
    public class GameHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            var gameResults = await _context.GameResults
                .Where(gr => gr.UserId == userId)
                .Include(gr => gr.User)
                .ToListAsync();

            return View(gameResults);
        }
    }
}
