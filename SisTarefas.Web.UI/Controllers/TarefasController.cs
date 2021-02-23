
using FluentValidation.Results;
using SisTarefas.Application.Interface;
using SisTarefas.Application.Models;
using SisTarefas.Application.Models.Validators;
using System.Collections.Generic;
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
            ViewBag.Contatos = ListarContatos();
            return View();
        }
        public ActionResult PartialContato()
        {
            return PartialView("_PartialCadastrarContato");
        }

        [HttpPost]
        public ActionResult CadastrarTarefa(TarefaViewModel tarefa)
        {
            var response = _appservice.Cadastrar(tarefa);

            return Json(response);
        }

        public ActionResult CadastrarContato(ContatosViewModel contato)
        {
            //ValidationResult validate = new ContatoValidator();

            var response = _appservice.CadastrarContato(contato);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNotification(NotificacoesViewModel notific)
        {
            var response = _appservice.AddNotification(notific);

            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Error()
        {
            return View("Error");
        }

        #region MÉTODOS QUE NÃO RETORNAM VIEW
        public List<string> ListarContatos()
        {
            List<string> response = _appservice.ListarContatos();

            return response;
        }
        #endregion
    }
}
