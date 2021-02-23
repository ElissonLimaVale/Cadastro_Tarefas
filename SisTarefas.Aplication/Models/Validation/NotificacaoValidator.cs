using FluentValidation;
using SisTarefas.Application.Models;

namespace SisTarefas.Application.Models.Validators
{
    public class NotificacaoValidator: AbstractValidator<NotificacoesViewModel>
    {
        public NotificacaoValidator()
        {
            RuleFor(x => x.nome).NotNull().NotEmpty().WithMessage("O atributo Nome deve ser especificados!");
            RuleFor(x => x.data).NotNull().NotEmpty().WithMessage("O atributo Data deve ser especificados!");
        }
    }
}