using Microsoft.AspNetCore.Mvc;
//using SisTarefas.Aplication.Interface;

namespace SisTarefas.WebUI.Controllers
{
    
    public class TarefasController : Controller
    {
        //private readonly ITarefasAppService _appservice;

        //public TarefasController(ITarefasAppService appservice)
        //{
        //    _appservice = appservice;
        //}
        public ActionResult Index()
        {
            return View("Index");
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
