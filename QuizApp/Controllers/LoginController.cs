using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using Microsoft.AspNetCore.Http;

namespace QuizApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly QuizContext quizContext;
        public LoginController(QuizContext _quizContext)
        {

            quizContext = _quizContext;

        }
        public IActionResult LogUser()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoginUser(Users user) {
            bool userExists = false;
            string url = "";
            int idUser = 0;

            if (quizContext.Users.Where(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password)) != null) {
                userExists = true;
                url = Url.Action("Index", "Home");
                idUser = quizContext.Users.Where(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password)).Select(u => u.IdUser).First();
                HttpContext.Session.SetString("username", user.Username);
            }

            return Json(new { userExists = userExists, url = url, idUser = idUser });
        }

        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(Users user)
        {
            //Adding new user into the table
            string message = string.Empty;
            try
            {
                if (quizContext.Users.Count(u => u.Username.Equals(user.Username)) == 0)
                {
                    quizContext.Users.Add(user);
                    quizContext.SaveChanges();
                    message = "Usuario creado " + user.Username;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(new { message = message, url= Url.Action("LogUser") });
        }
    }
}
