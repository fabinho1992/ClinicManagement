using BookReviewManager.Domain.IServices.Autentication;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.CommandsAuth.ComandCreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, ResultViewModel<string>>
    {
        private readonly ICreateRole _createRole;

        public CreateRoleCommandHandler(ICreateRole createRole)
        {
            _createRole = createRole;
        }

        public async Task<ResultViewModel<string>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var roleResult = await _createRole.CreateRoleAsync(request.Name);

            if (roleResult.Status == "200")
            {
                return ResultViewModel<string>.Success(roleResult.Message!);
            }

            return ResultViewModel<string>.Error(roleResult.Message!);
        }
    }
}
