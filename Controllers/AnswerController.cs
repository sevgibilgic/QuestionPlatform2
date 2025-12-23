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
    public class AnswerController : Controller
    {
        private readonly AnswerRepository _answerRepository;
        private readonly QuestionRepository _questionRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnswerController(
            AnswerRepository answerRepository,
            QuestionRepository questionRepository,
            UserManager<ApplicationUser> userManager)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Add(int questionId)
        {
            var question = await _questionRepository.GetByIdAsync(questionId);
            if (question == null)
                return NotFound();

            var model = new AnswerModel
            {
                QuestionId = questionId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AnswerModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var answer = new Answer
            {
                QuestionId = model.QuestionId,
                AnswerContent = model.AnswerContent,
                UserId = user.Id,
                CreatedAt = DateTime.Now
            };

            await _answerRepository.AddAsync(answer);

            return RedirectToAction("Details", "Question", new { id = model.QuestionId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var answer = await _answerRepository
                .Where(x => x.Id == id)
                .Include(x => x.Question)
                .FirstOrDefaultAsync();

            if (answer == null)
                return NotFound();

            return View(answer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Answer model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var entity = await _answerRepository.GetByIdAsync(model.Id);
            if (entity == null)
                return NotFound();

            entity.AnswerContent = model.AnswerContent;
            entity.UpdatedAt = DateTime.Now;

            await _answerRepository.UpdateAsync(entity);

            return RedirectToAction("Details", "Question", new { id = entity.QuestionId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var answer = await _answerRepository
                .Where(x => x.Id == id)
                .Include(x => x.Question)
                .FirstOrDefaultAsync();

            if (answer == null)
                return NotFound();

            int questionId = answer.QuestionId;

            await _answerRepository.DeleteAsync(id);

            return RedirectToAction("Details", "Question", new { id = questionId });
        }
    }
}
