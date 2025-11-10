using Microsoft.AspNetCore.Identity;
using WarrantyAPITest.Interfaces;
using WarrantyAPITest.Models;

namespace WarrantyAPITest.Repository
{
    public class AccountRepository : IAccountRepository

    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> SignUpAsync(SignUp signupModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = signupModel.FirstName,
                SecondName = signupModel.SecondName,
                Email = signupModel.Email,
                UserName = signupModel.Email
            };
            return await _userManager.CreateAsync(user, signupModel.Password);
        }
    }
}
