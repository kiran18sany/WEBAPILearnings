using Microsoft.AspNetCore.Identity;
using WarrantyAPITest.Models;

namespace WarrantyAPITest.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUp signupModel);

    }
}