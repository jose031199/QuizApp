using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        private readonly QuizContext quizContext;
        public QuizController(QuizContext _quizContext)
        {

            quizContext = _quizContext;

        }
        public IActionResult Questions()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addUser_Answers(UsersAnswers answers)
        {
            string url = "";
            
            try
            {
                url = Url.Action("Index", "Home");
                var answerUpdate = quizContext.UsersAnswers.Where(u => u.UserId.Equals(answers.UserId) && u.Category.Equals(answers.Category) && u.Level.Equals(answers.Level)).FirstOrDefault();
                if (answerUpdate!= null) {
                    answerUpdate.CorrectAnswers = answers.CorrectAnswers;
                }
                else
                {
                    quizContext.UsersAnswers.Add(answers);
                }
                quizContext.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            
            return Json(new { url = url });
        }
    }
}
