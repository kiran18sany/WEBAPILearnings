using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarrantyAPITest.Data;
using WarrantyAPITest.Models;

namespace WarrantyAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EwclaimPartMaster1Controller(GaponlineDemo1Context context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<EwclaimPartMaster>>> GetAll()
        {
            return await context.EwclaimPartMasters.ToListAsync();
        }
    }
}
