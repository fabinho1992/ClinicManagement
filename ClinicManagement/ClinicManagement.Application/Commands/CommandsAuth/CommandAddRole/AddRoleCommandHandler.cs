using BookReviewManager.Domain.IServices.Autentication;
using BookReviewManager.Infrastructure.Service.Identity;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.CommandsAuth.CommandAddRole
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, ResultViewModel<string>>
    {
        private readonly IAddRole _addRole;

        public AddRoleCommandHandler(IAddRole addRole)
        {
            _addRole = addRole;
        }

        public async Task<ResultViewModel<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var roleResult = await _addRole.AdicionarRoles(request.Email, request.NameRole);

            if (roleResult.Status == "200")
            {
                return ResultViewModel<string>.Success(roleResult.Message!);
            }

            return ResultViewModel<string>.Error(roleResult.Message!);
        }
    }
}
