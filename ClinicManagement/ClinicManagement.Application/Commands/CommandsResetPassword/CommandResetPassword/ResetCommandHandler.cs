using ClinicManagement.Domain.IRepository;
using ClinicManagement.Domain.Services.EmailServices;
using ClinicManagement.Infrastructure.Context.User;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.CommandsResetPassword.CommandResetPassword
{
    public class ResetCommandHandler : IRequestHandler<ResetCommand, ResultViewModel<string>>
    {
        private readonly ISendEmail _sendEmail;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMemoryCache _cache;

        public ResetCommandHandler(ISendEmail sendEmail, IMemoryCache cache, UserManager<ApplicationUser> userManager)
        {
            _sendEmail = sendEmail;
            _cache = cache;
            _userManager = userManager;
        }

        public async Task<ResultViewModel<string>> Handle(ResetCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            var code = new Random().Next(100000, 999999).ToString();


            if(user is null)
            {
                return ResultViewModel<string>.Error("Email não existe!");
            }
                var keyCache = $"RecoveryCode:{request.Email}";
                _cache.Set(keyCache, code, TimeSpan.FromDays(1));

                user.ResetToken = code;
                await _userManager.UpdateAsync(user);

                await _sendEmail.ResetPassword(user.Email, user.Email, code);
            

            return ResultViewModel<string>.Success("Código de recuperação enviado para seu e-mail");

            
        }
    }
}
