using Core.DataAccess.Repositories;
using HospitalProject.Model.Entities;

namespace HospitalProject.DataAccess.Repositories.Abstracts;

public interface IPatientRepository : IRepository<Patient, int>, IAsyncRepository<Patient, int>
{
}
