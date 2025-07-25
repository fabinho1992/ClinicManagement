using FinancialGoalsManager.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Commands.CommandsResetPassword.CommandChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ResultViewModel<string>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMemoryCache _cache;

        public ChangePasswordCommandHandler(UserManager<IdentityUser> userManager, IMemoryCache cache)
        {
            _userManager = userManager;
            _cache = cache;
        }

        public async Task<ResultViewModel<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            // 1. Validar o código de recuperação
            var keyCache = $"RecoveryCode:{request.Email}";
            if (!_cache.TryGetValue(keyCache, out string? code) || code != request.Code)
            {
                return ResultViewModel<string>.Error("Código de recuperação inválido.");
            }

            // 2. Buscar o usuário pelo e-mail
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return ResultViewModel<string>.Error("Usuário não encontrado.");
            }


            // 3. Gerar um novo hash de senha
            var newPasswordHash = _userManager.PasswordHasher.HashPassword(user, request.Password);

            // 4. Atualizar o hash da senha no usuário
            user.PasswordHash = newPasswordHash;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                // Lidar com erros
                return ResultViewModel<string>.Error("Falha ao alterar a senha.");
            }

            // 4. Remover o código do cache (opcional, mas recomendado)
            _cache.Remove(keyCache);

            // 5. Retornar sucesso
            return ResultViewModel<string>.Success("Senha alterada com sucesso!");
        }
    }
}
