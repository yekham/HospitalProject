﻿using Core.DataAccess.Repositories;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HospitalProject.DataAccess.Repositories.Concretes;

public sealed class DoctorRepository : EfRepositoryBase<Doctor, int, BaseDbContext>, IDoctorRepository
{
    public DoctorRepository(BaseDbContext context) : base(context)
    {
    }
    public async Task<int> CountAsync(Expression<Func<Doctor, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Doctors.CountAsync(predicate, cancellationToken);
    }
}
