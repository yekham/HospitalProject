using Core.DataAccess.Repositories;
using HospitalProject.Model.Entities;
using System.Linq.Expressions;

namespace HospitalProject.DataAccess.Repositories.Abstracts;

public interface IDoctorRepository : IRepository<Doctor, int>, IAsyncRepository<Doctor, int>
{
    Task<int> CountAsync(Expression<Func<Doctor, bool>> predicate, CancellationToken cancellationToken = default);
}
