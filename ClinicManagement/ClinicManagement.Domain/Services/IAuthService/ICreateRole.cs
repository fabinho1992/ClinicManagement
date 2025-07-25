using BookReviewManager.Domain.ModelsAutentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.IServices.Autentication
{
    public interface ICreateRole
    {
        Task<ResponseIdentityCreate> CreateRoleAsync(string roleName);
    }
}
