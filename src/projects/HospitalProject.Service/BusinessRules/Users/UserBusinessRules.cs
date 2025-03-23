using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.DataAccess.Repositories.Concretes;
using HospitalProject.Service.Constants.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Service.BusinnessRules.Users;

public class UserBusinessRules(IUserRepository userRepository)
{
    public async Task UsernameMustBeUniqueAsync(string username)
    {
        bool isPresent = await userRepository.AnyAsync(x => x.Username == username);
        if (isPresent)
            throw new BusinessException(UserMessages.UsernameMustBeUnique);
    }

    public async Task EmailMustBeUniqueAsync(string email)
    {
        bool isPresent = await userRepository.AnyAsync(x => x.Email == email);
        if (isPresent)
            throw new BusinessException(UserMessages.EmailMustBeUnique);
    }


    public async Task UserIsPresent(int id)
    {
        bool isPresent = await userRepository.AnyAsync(x => x.Id == id);
        if (!isPresent)
            throw new NotFoundException(UserMessages.UserNotFound);
    }


    public async Task SearchByEmailAsync(string email)
    {
        bool isPresent = await userRepository.AnyAsync(x => x.Email == email);
        if (!isPresent)
            throw new NotFoundException(UserMessages.UserNotFound);
    }


    //// Kullanıcı sadece kendi randevusunu görebilir ve güncelleyebilir
    //public void EnsureUserOwnsAppointment(int userId, int appointmentUserId)
    //{
    //    if (userId != appointmentUserId)
    //    {
    //        throw new BusinessException("Sadece kendi randevunuz üzerinde işlem yapabilirsiniz.");
    //    }
    //}


}
