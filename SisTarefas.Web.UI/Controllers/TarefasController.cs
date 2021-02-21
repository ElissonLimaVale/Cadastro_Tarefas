
using SisTarefas.Aplication.Interface;

using System.Web.Mvc;

namespace SisTarefas.WebUI.Controllers
{
    
    public class TarefasController : Controller
    {
        private readonly ITarefasAppService _appservice;

        public TarefasController(ITarefasAppService appservice)
        {
            _appservice = appservice;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar()
        {
            var response = new { data = true, message = "Cadastrado com sucesso!" };

            return Json(response);
        }

        public ActionResult Error()
        {
            return View("Error");
        }
    }
}
