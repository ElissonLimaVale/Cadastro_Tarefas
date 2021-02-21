
using SisTarefas.Application.Interface;
using SisTarefas.Application.Models;
using System.Web.Mvc;

namespace SisTarefas.WebUI.Controllers
{
    
    public class TarefasController : Controller
    {
        private readonly ITarefasAppService _appservice;

        //public TarefasController(ITarefasAppService appservice)
        //{
        //    _appservice = appservice;
        //}

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialContato()
        {
            return PartialView("_PartialCadastrarContato");
        }

        [HttpPost]
        public ActionResult Cadastrar(TarefaViewModel tarefa)
        {
            var response = _appservice.Cadastrar(tarefa);

            return Json(response);
        }

        public ActionResult Error()
        {
            return View("Error");
        }
    }
}
