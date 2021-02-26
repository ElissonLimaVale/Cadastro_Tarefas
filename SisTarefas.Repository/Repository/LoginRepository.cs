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

        public dynamic Cadastrar(Usuario user)
        {
            dynamic response;
            try
            {
                user.senha = BCrypt.Net.BCrypt.HashPassword(user.senha);
                var registro = _entity.Usuario.FirstOrDefault(x => x.email == user.email);
                if(registro == null)
                {
                    _entity.Usuario.Add(user);
                    _entity.SaveChanges();

                    user.senha = null;
                    response = new { data = true, message = "Cadastrado! Aguarde, você esta sendo redirecionado!", usuario = user };
                }
                else
                {
                    response = new { data = false, message = "Usuario ja existente!", usuario = user };
                }
            }
            catch(Exception ex)
            {
                response = new { data = false, message = ex.ToString(), usuario = new Usuario() };
            }
            

            return response;
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
                registro.telefone = user.telefone;
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
            Usuario response = new Usuario();
            try
            {
                var registro = _entity.Usuario.FirstOrDefault(x => x.email == user.email);
                if (registro != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(user.senha, registro.senha))
                    {
                        response.nome = registro.nome;
                        response.email = registro.email;
                        response.telefone = registro.telefone;
                        response.senha = null;
                    }
                    else
                    {
                        response = null;
                    }
                }
                
            }
            catch(Exception ex)
            {
                response = null;
            }
            
            return response;
        }
    }
}
