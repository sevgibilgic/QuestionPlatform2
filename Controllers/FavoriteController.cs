using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly FavoriteRepository _favoriteRepository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FavoriteController(FavoriteRepository favoriteRepository, AppDbContext context, IMapper mapper)
        {
            _favoriteRepository = favoriteRepository;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> ToggleAjax(FavoriteModel model)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var existing = await _favoriteRepository
                .Where(f => f.QuestionId == model.QuestionId && f.UserId == userId)
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
            else
            {
                var fav = new Favorite
                {
                    QuestionId = model.QuestionId,
                    UserId = userId,
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
        }

        public async Task<IActionResult> MyFavorites()
        {
            var userId = int.Parse(HttpContext.User.FindFirst("UserId").Value);

            var list = await _context.Favorites
                .Where(f => f.UserId == userId)
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
