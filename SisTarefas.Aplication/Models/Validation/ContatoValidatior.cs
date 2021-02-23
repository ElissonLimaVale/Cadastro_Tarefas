using FluentValidation;
using SisTarefas.Application.Models;

namespace SisTarefas.Application.Models.Validators
{
    public class ContatoValidator: AbstractValidator<ContatosViewModel>
    {
        public ContatoValidator()
        {
            RuleFor(x => x.nome).NotEmpty().NotNull().WithMessage("O atributo Nome deve ser especificado!");

            RuleFor(x => x.email).NotEmpty().NotNull().WithMessage("O atributo Email deve ser especificado!");

            RuleFor(x => x.telefone).NotEmpty().NotNull().WithMessage("O atributo Numero de Telefone deve ser especificado!");
        }
    }
}