using AutoMapper;
using SisTarefas.Interface;
using SisTarefas.Application.Models;
using SisTarefas.Domain.Base;
using SisTarefas.Repository.Interface;
using System.Collections.Generic;

namespace SisTarefas.Aplication
{
    public class LoginAppService: ILoginAppService
    {
        private readonly ILoginRepository _repository;
        public LoginAppService(ILoginRepository repository)
        {
            _repository = repository;
        }

        public dynamic Atualizar(UsuarioViewModel user)
        {
            return _repository.Atualizar(Mapper.Map<UsuarioViewModel, Usuario>(user));
        }

        public dynamic Cadastrar(UsuarioViewModel user)
        {
            dynamic response = _repository.Cadastrar(Mapper.Map<UsuarioViewModel, Usuario>(user));
            return response;
        }

        public dynamic Deletar(UsuarioViewModel user)
        {
            return _repository.Deletar(Mapper.Map<UsuarioViewModel, Usuario>(user));
        }

        public UsuarioViewModel Logar(UsuarioViewModel user)
        {
             return Mapper.Map<Usuario, UsuarioViewModel>(_repository.Logar(Mapper.Map<UsuarioViewModel, Usuario>(user)));
        }

        public List<UsuarioViewModel> ListarUsuarios()
        {
            return Mapper.Map<List<Usuario>,List<UsuarioViewModel>>(_repository.ListarUsuarios());
        }

        public UsuarioViewModel BuscarUsuario(string nome)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_repository.BuscarUsuario(nome));
        }
    }
}
