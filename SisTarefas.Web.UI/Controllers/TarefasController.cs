
using FluentValidation.Results;
using SisTarefas.Interface;
using SisTarefas.Application.Interface;
using SisTarefas.Application.Models;
using SisTarefas.Application.Models.Validators;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace SisTarefas.WebUI.Controllers
{
    
    public class TarefasController : Controller
    {
        private readonly ITarefasAppService _appservice;
        private readonly TarefaValidator _tarefa;
        private readonly ContatoValidator _contato;
        private readonly NotificacaoValidator _notific;
        private readonly ILoginAppService _log;
        private UsuarioViewModel _usuario;
        public TarefasController(ITarefasAppService appservice, 
                                TarefaValidator tarefa,
                                ContatoValidator contato,
                                NotificacaoValidator notific,
                                ILoginAppService log
            )
        {
            _appservice = appservice;
            _tarefa = tarefa;
            _contato = contato;
            _notific = notific;
            _log = log;
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
        public ActionResult CadastrarTarefa(TarefaViewModel tarefa, List<UsuarioViewModel> contato)
        {
            dynamic response;
            _usuario = Session["usuario"] as UsuarioViewModel;
            if (_usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
            //FluentValidation
            ValidationResult result = _tarefa.Validate(tarefa);
            NotificacoesViewModel notific = new NotificacoesViewModel();
            UsuarioViewModel user = new UsuarioViewModel();

            if (result.IsValid)
            {
                response = _appservice.Cadastrar(tarefa);
                tarefa = _appservice.BuscarTarefa(tarefa);

                foreach (UsuarioViewModel item in contato)
                {
                    notific.nome = item.nome;
                    notific.response = false;
                    notific.data = DateTime.Now;
                    notific.dataconclusao = tarefa.data_prevista;
                    notific.Tarefa = tarefa;

                    _appservice.AddNotification(notific);
                    user = _log.BuscarUsuario(item.nome);
                    user.Tarefas = tarefa;
                    _log.Atualizar(user);
                }
                
            }
            else {
                response = new { data = false, message = result.ToString("") };
            }
            
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

        [HttpPost]
        public ActionResult NotificationVerific()
        {
            _usuario = Session["usuario"] as UsuarioViewModel;
            if (_usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }

            dynamic response = _appservice.NotificationVerific(_usuario.id);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Error()
        {
            return PartialView("Error");
        }

        #region MÉTODOS QUE NÃO RETORNAM VIEW
        public List<UsuarioViewModel> ListarContatos()
        {
            List<UsuarioViewModel> response = _log.ListarUsuarios();//_appservice.ListarContatos();

            return response;
        }
        #endregion
    }
}
