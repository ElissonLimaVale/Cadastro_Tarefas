using SisAtividades.Interface;
using SisAtividades.Models;
using System.Web.Mvc;

namespace SisTarefas.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginAppService _log;
        public LoginController(ILoginAppService log)
        {
            _log = log;
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Logar(string email, string senha)
        {
            var user = new UsuarioViewModel();
            user.nome = email;
            user.senha = senha;

            user = _log.Logar(user);

            Session["Usuario"] = user;

            return RedirectToAction("Tarefas","Index");
        }
    }
}