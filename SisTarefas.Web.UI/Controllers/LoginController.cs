using SisAtividades.Interface;
using System.Web.Http;
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
    }
}