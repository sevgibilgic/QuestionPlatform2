using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;

namespace QuestionPlatform2.Controllers
{
    public class AnswerController : Controller
    {
        private readonly AnswerRepository _answerRepository;
        private readonly QuestionRepository _questionRepository;

        public AnswerController(AnswerRepository answerRepository, QuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }

        public async Task<IActionResult> Add(int questionId)
        {
            var question = await _questionRepository.GetByIdAsync(questionId);
            if (question == null)
                return NotFound();

            var model = new Answer
            {
                Question = question
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Answer model, int questionId)
        {
            var question = await _questionRepository.GetByIdAsync(questionId);
            if (question == null)
                return NotFound();

            model.Question = question;

            if (!ModelState.IsValid)
                return View(model);

            await _answerRepository.AddAsync(model);

            return RedirectToAction("Details", "Question", new { id = questionId });
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

            await _answerRepository.UpdateAsync(model);

            return RedirectToAction("Details", "Question", new { id = model.Question.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var answer = await _answerRepository
                .Where(x => x.Id == id)
                .Include(x => x.Question)
                .FirstOrDefaultAsync();

            if (answer == null)
                return NotFound();

            int questionId = answer.Question.Id;

            await _answerRepository.DeleteAsync(id);

            return RedirectToAction("Details", "Question", new { id = questionId });
        }
    }
}
