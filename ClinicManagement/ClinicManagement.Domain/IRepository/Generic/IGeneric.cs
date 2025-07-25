using BloodDonationDataBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.IRepository.Generic
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
        Task<(IEnumerable<T> items, int totalCount)> GetAll(ParametrosPaginacao parametrosPaginacao);
    }
}
