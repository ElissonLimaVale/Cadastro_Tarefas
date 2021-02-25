
using FluentValidation.Results;
using SisAtividades.Models;
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
        private UsuarioViewModel _usuario;
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
            _usuario = Session["usuario"] as UsuarioViewModel;
            if (_usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
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
            _usuario = Session["usuario"] as UsuarioViewModel;
            if (_usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
            //FluentValidation
            ValidationResult result = _tarefa.Validate(tarefa);
            
            dynamic response = result.IsValid ? _appservice.Cadastrar(tarefa) : new { data = false, message = result.ToString("") };
            
            return Json(response);
        }

        [HttpPost]
        public ActionResult BuscarTarefa(int id)
        {
            _usuario = Session["usuario"] as UsuarioViewModel;
            if (_usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
            TarefaViewModel response = _appservice.BuscarTarefa(id);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CadastrarContato(ContatosViewModel contato)
        {
            _usuario = Session["usuario"] as UsuarioViewModel;
            if (_usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
            //FluentValidation
            ValidationResult result = _contato.Validate(contato);

            dynamic response = result.IsValid ? _appservice.CadastrarContato(contato) : response = new { data = false, message = result.ToString("") };
            
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNotification(NotificacoesViewModel notific)
        {
            _usuario = Session["usuario"] as UsuarioViewModel;
            if (_usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
            //FluentValidation
            ValidationResult result = _notific.Validate(notific);

            dynamic response = result.IsValid ? _appservice.AddNotification(notific) : new { data = false, message = result.ToString("") };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NotificationVerific(string nome)
        {
            _usuario = Session["usuario"] as UsuarioViewModel;
            if (_usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return _appservice.NotificationVerific(nome);
        }

        public ActionResult Error()
        {
            return PartialView("Error");
        }

        #region MÉTODOS QUE NÃO RETORNAM VIEW
        public List<string> ListarContatos()
        {
            List<string> response = _appservice.ListarContatos();

            return response;
        }

        private bool ValidarParams(dynamic[] parametros)
        {
            bool response = true;

            foreach(dynamic item in parametros)
            {
                if(item == null || item == "")
                {
                    response = false;
                }
            }
            return response;

        }
        #endregion
    }
}
