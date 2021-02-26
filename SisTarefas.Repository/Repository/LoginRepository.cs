
using SisTarefas.Domain.Base;
using SisTarefas.Repository.Base;
using SisTarefas.Repository.Context;
using SisTarefas.Repository.Interface;
using System;
using System.Linq;

namespace SisTarefas.Repository.Repository
{
    public class LoginRepository: ILoginRepository
    {
        private readonly Conexao _conexao;
        private readonly CadastroTarefasContext _entity;
        public LoginRepository(Conexao conexao,
                               CadastroTarefasContext entity
            )
        {
            _conexao = conexao;
            _entity = entity;
        }

        public Usuario Cadastrar(Usuario user)
        {

            _entity.Usuario.Add(user);
            _entity.SaveChanges();

            return user;
        }

        public dynamic Deletar(Usuario user)
        {
            dynamic response = new { data = true, message = "Deletado com sucesso!" };
            try
            {
                var registro = _entity.Usuario.FirstOrDefault(
                    x => x.nome == user.nome &&
                    x.email == user.email
                );
                _entity.Usuario.Remove(registro);
                _entity.SaveChanges();
            }
            catch(Exception ex)
            {
                response = new { data = false, message = ex.ToString() };
            }

            return response;
        }

        public dynamic Atualizar(Usuario user)
        {
            dynamic response = new { data = true, message = "Atualizado com sucesso!" };
            try
            {
                var registro = _entity.Usuario.FirstOrDefault(
                    x => x.nome == user.nome &&
                    x.email == user.email
                );
                registro.nome = user.nome;
                registro.email = user.email;
                //registro.senha = user.senha;
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                response = new { data = false, message = ex.ToString() };
            }

            return response;
        }

        public Usuario Logar(Usuario user)
        {
            return new Usuario();
        }
    }
}
