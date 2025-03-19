﻿using FluentValidation;
using HospitalProject.Service.Abstracts;
using HospitalProject.Service.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HospitalProject.Service;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IHospitalService, HospitalService>();
        services.AddScoped<IPatientService, PatientService>();
        
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

       
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        
        return services;
    }
}
