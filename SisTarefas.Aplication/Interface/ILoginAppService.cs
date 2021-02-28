
using SisTarefas.Application.Models;
using System.Collections.Generic;

namespace SisTarefas.Interface
{
    public interface ILoginAppService
    {
        dynamic Cadastrar(UsuarioViewModel user);
        dynamic Atualizar(UsuarioViewModel user);
        dynamic Deletar(UsuarioViewModel user);
        UsuarioViewModel Logar(UsuarioViewModel user);
        List<UsuarioViewModel> ListarUsuarios();
        UsuarioViewModel BuscarUsuario(string nome);
    }
}
