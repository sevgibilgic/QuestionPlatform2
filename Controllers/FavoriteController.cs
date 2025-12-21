using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly FavoriteRepository _favoriteRepository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoriteController(
            FavoriteRepository favoriteRepository,
            AppDbContext context,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _favoriteRepository = favoriteRepository;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> ToggleAjax(FavoriteModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var existing = await _favoriteRepository
                .Where(f => f.QuestionId == model.QuestionId && f.UserId == user.Id)
                .FirstOrDefaultAsync();

            if (existing != null)
            {
                await _favoriteRepository.DeleteAsync(existing.Id);

                return Json(new
                {
                    status = true,
                    message = "Favoriden çıkarıldı",
                    data = new { isFavorite = false }
                });
            }

            var fav = new Favorite
            {
                QuestionId = model.QuestionId,
                UserId = user.Id,
                CreatedAt = DateTime.Now
            };

            await _favoriteRepository.AddAsync(fav);

            return Json(new
            {
                status = true,
                message = "Favoriye eklendi",
                data = new { isFavorite = true }
            });
        }

        public async Task<IActionResult> MyFavorites()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var list = await _context.Favorites
                .Where(f => f.UserId == user.Id)
                .Include(f => f.Question)
                .ToListAsync();

            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAjax(int id)
        {
            await _favoriteRepository.DeleteAsync(id);

            return Json(new
            {
                status = true,
                message = "Favori kaldırıldı"
            });
        }
    }
}
