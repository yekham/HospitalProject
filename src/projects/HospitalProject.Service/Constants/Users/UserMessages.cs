using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Service.Constants.Users;

public static class UserMessages
{
    public const string UserNotFound = "Kullanici bulunamadi";
    public const string UsernameMustBeUnique = "Kullanici adi bensersiz olmalidir.";
    public const string EmailMustBeUnique = "Email alani bensersiz olmalidir.";
    public const string PasswordIsWrong = "Parola yanlis";

    public const string UserAdded = "User added successfully";
    public const string UserDeleted = "User deleted successfully";
}
