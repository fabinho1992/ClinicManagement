
using BloodDonationDataBase.Domain.Models;
using ClinicManagement.Domain.IRepository.Generic;
using ClinicManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infraestrutura.Repository.Generic
{
    public class RepositoryBase<T> : IGeneric<T> where T : class
    {
        private readonly ClinicDbContext _contextBase;
        
        
        public RepositoryBase(ClinicDbContext contextBase)
        {
            _contextBase = contextBase;
            
        }

        public async Task Add(T entity)
        {
             await _contextBase.Set<T>().AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            var entityId = await _contextBase.Set<T>().FindAsync(id);
            _contextBase.Set<T>().Remove(entityId);
        }

        public async Task<(IEnumerable<T> items, int totalCount)> GetAll(ParametrosPaginacao parametrosPaginacao)
        {
            var query = _contextBase.Set<T>().AsNoTracking();

            // Primeiro obtemos o total de registros
            var totalCount = await query.CountAsync();

            // Depois aplicamos a paginação
            var items = await query
                .Skip((parametrosPaginacao.PageNumber - 1) * parametrosPaginacao.PageSize)
                .Take(parametrosPaginacao.PageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task Update(T entity)
        {
            _contextBase.Set<T>().Update(entity);
        }
    }
}
