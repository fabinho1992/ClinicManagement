using FinancialGoalsManager.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.CommandsResetPassword.CommandValidateCode
{
    public class CodeCommandHandler : IRequestHandler<ValidateCodeCommand, ResultViewModel>
    {
        private readonly IMemoryCache _cache;
        private readonly UserManager<IdentityUser> _userManager;

        public CodeCommandHandler(IMemoryCache cache, UserManager<IdentityUser> userManager)
        {
            _cache = cache;
            _userManager = userManager;
        }

        public async Task<ResultViewModel> Handle(ValidateCodeCommand request, CancellationToken cancellationToken)
        {
            var keyCache = $"RecoveryCode:{request.Email}";

            if (!_cache.TryGetValue(keyCache, out string? code) || code != request.Code)
            {
                Console.WriteLine($"Esse é o código :{code}");
                return ResultViewModel.Error("Código não está válido!");
            }

            return ResultViewModel.Success();
        }
    }
}
