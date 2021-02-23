
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
        private readonly TarefaValidator _tarefa;
        private readonly ContatoValidator _contato;
        private readonly NotificacaoValidator _notific;

        public TarefasController(ITarefasAppService appservice, 
                                TarefaValidator tarefa,
                                ContatoValidator contato,
                                NotificacaoValidator notific
            )
        {
            _appservice = appservice;
            _tarefa = tarefa;
            _contato = contato;
            _notific = notific;
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
            //FluentValidation
            ValidationResult result = _tarefa.Validate(tarefa);
            
            dynamic response = result.IsValid ? _appservice.Cadastrar(tarefa) : new { data = false, message = result.ToString("") };
            
            return Json(response);
        }

        public ActionResult CadastrarContato(ContatosViewModel contato)
        {
            //FluentValidation
            ValidationResult result = _contato.Validate(contato);

            dynamic response = result.IsValid ? _appservice.CadastrarContato(contato) : response = new { data = false, message = result.ToString("") };
            
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNotification(NotificacoesViewModel notific)
        {
            //FluentValidation
            ValidationResult result = _notific.Validate(notific);

            dynamic response = result.IsValid ? _appservice.AddNotification(notific) : new { data = false, message = result.ToString("") };

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
