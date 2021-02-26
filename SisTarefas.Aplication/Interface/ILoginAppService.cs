using SisAtividades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAtividades.Interface
{
    public interface ILoginAppService
    {
        UsuarioViewModel Cadastrar(UsuarioViewModel user);
        dynamic Atualizar(UsuarioViewModel user);
        dynamic Deletar(UsuarioViewModel user);

        UsuarioViewModel Logar(UsuarioViewModel user);
    }
}
