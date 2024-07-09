using CasoPractico1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CasoPractico1.Controllers
{
    public class GameController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public GameController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> EndGame(int score, TimeSpan duration)
        {
            var user = await _userManager.GetUserAsync(User);

            var gameResult = new GameResult
            {
                UserId = user.Id,
                Score = score,
                Duration = duration,
                Date = DateTime.Now
            };

            _context.GameResults.Add(gameResult);
            await _context.SaveChangesAsync();

            return View("GameResult", gameResult);
        }
    }
}
