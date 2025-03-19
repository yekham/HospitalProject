using Core.DataAccess.Repositories;
using HospitalProject.Model.Entities;

namespace HospitalProject.DataAccess.Repositories.Abstracts;

public interface IHospitalRepository : IRepository<Hospital, int>, IAsyncRepository<Hospital, int>
{
}
