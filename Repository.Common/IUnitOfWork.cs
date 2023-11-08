using DAL;
using Microsoft.EntityFrameworkCore.Migrations;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<VehicleMake> vehicleMakeRepo { get; }
        IGenericRepository<VehicleModel> vehicleModelRepo { get; }
        Task<int> AddAsync<T>(T entity) where T : class;

        Task<int> CommitAsync();

        Task<int> DeleteAsync<T>(T entity) where T : class;

        Task<int> DeleteAsync<T>(int id) where T : class;

        Task<int> UpdateAsync<T>(T entity) where T : class;
    }
}
