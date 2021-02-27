using FluentValidation.Results;
using SisAtividades.Interface;
using SisAtividades.Models;
using SisAtividades.Models.Validation;
using System.Web.Mvc;
using SisTarefas.Web;

namespace SisTarefas.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginAppService _log;
        private readonly UsuarioValidator _usuario;
        public LoginController(ILoginAppService log, UsuarioValidator usuario)
        {
            _log = log;
            _usuario = usuario;
        }

        public ActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        public ActionResult Logar(string email, string senha)
        {
            dynamic response = new { data = true, message = "Aguarde estamos redirecionando!" };

            if (Utils.ValidaParams(new dynamic[] { email, senha}))
            {
                var user = new UsuarioViewModel(null, email, null, senha);
                senha = null; //remove  string de senha da memoria
                var usuario = _log.Logar(user);

                if (usuario != null)
                {
                    Session["usuario"] = usuario;
                }
                else
                {
                    response = new { data = false, message = "Usuario ou senha incorretos!" };
                }
            }else
            {
                response = new { data = false, message = "Email e senha devem ser especificados!" };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Cadastar(UsuarioViewModel Usuario)
        {
            dynamic response;
            ValidationResult result = _usuario.Validate(Usuario);
            if (result.IsValid)
            {
                dynamic data = _log.Cadastrar(Usuario);

                if (data.GetType().GetProperty("data").GetValue(data, null))
                {
                    Session["usuario"] = data.GetType().GetProperty("usuario").GetValue(data, null);
                    response = new { data = true, message = "Cadastrado! Aguarde, estamos redirecionando!" };
                }
                else
                {
                    response = new { data = false, message = data.GetType().GetProperty("message").GetValue(data, null) };
                }
            }
            else
            {
                response = new { data = false, message = result.ToString("") };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }


        
    }
}