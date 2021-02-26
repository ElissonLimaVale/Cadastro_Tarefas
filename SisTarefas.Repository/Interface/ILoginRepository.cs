

using SisTarefas.Domain.Base;

namespace SisTarefas.Repository.Interface
{
    public interface ILoginRepository
    {
        dynamic Cadastrar(Usuario user);
        dynamic Atualizar(Usuario user);
        dynamic Deletar(Usuario user);
        Usuario Logar(Usuario user);
    }
}
