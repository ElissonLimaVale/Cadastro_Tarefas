

using SisTarefas.Domain.Base;
using System.Collections.Generic;

namespace SisTarefas.Repository.Interface
{
    public interface ILoginRepository
    {
        dynamic Cadastrar(Usuario user);
        dynamic Atualizar(Usuario user);
        dynamic Deletar(Usuario user);
        Usuario Logar(Usuario user);
        List<Usuario> ListarUsuarios();
        Usuario BuscarUsuario(string nome);
    }
}
