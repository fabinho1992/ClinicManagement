using BookReviewManager.Domain.ModelsAutentication;
using FinancialGoalsManager.Application.Dtos;
using MediatR;

namespace BookReviewManager.Application.Commands.CommandsAuth.CommandAddUser
{
    public class CreateUserCommand : IRequest<ResultViewModel<ResponseIdentityCreate>>
    {
        public CreateUserCommand(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
