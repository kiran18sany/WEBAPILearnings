using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarrantyAPITest.Interfaces;
using WarrantyAPITest.Models;
using WarrantyAPITest.Repository;

namespace WarrantyAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signupModel) {
           
            var result=await _accountRepository.SignUpAsync(signupModel);
                if (result.Succeeded) {
                    return Ok(result);
                }
                return Unauthorized();
                
           
        }

      
    }
}
