

using FluentValidation;
using SisTarefas.Application.Models;

namespace SisTarefas.Models.Validation
{
    public class UsuarioValidator: AbstractValidator<UsuarioViewModel>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.nome).NotEmpty().NotNull().WithMessage("O nome de usuario deve ser especificado!");
            RuleFor(x => x.email).NotEmpty().NotNull().WithMessage("O email deve ser especificado!");
            RuleFor(x => x.telefone).NotEmpty().NotNull().WithMessage("O telefone deve ser especificado!");
            RuleFor(x => x.senha).NotEmpty().NotNull().WithMessage("A senha deve ser especificada!");
        }

    }
}
