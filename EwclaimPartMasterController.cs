using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarrantyAPITest.Data;
using WarrantyAPITest.Interfaces;
using WarrantyAPITest.Models;

namespace WarrantyAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EwclaimPartMasterController: ControllerBase
    {
        private readonly IEwclaimPartMasterRepository _IEwclaimPartMasterRepository;

        public EwclaimPartMasterController(IEwclaimPartMasterRepository objIEwclaimPartMasterRepository)
        {
            _IEwclaimPartMasterRepository = objIEwclaimPartMasterRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAllParts() { 
            var parts=await _IEwclaimPartMasterRepository.GetAllAsync();
            return Ok(parts);
        
        }
        [HttpGet("{partnum}")]
        public async Task<ActionResult> GetPartsByID([FromRoute] int partnum)
        {
            var ewclaimPartMasters = await _IEwclaimPartMasterRepository.GetByIdAsync(partnum);
            return Ok(ewclaimPartMasters);

        }
        //public async Task<ActionResult> GetPartsByID([FromRoute]string partnum)
        //{
        //    var ewclaimPartMasters = await _IEwclaimPartMasterRepository.GetByIdAsync(partnum);
        //    return Ok(ewclaimPartMasters);

        //}

        [HttpPost("")]
        public async Task<ActionResult> AddNewPart([FromBody] EwclaimPartMaster _part)
        {
            var partNo = await _IEwclaimPartMasterRepository.AddAsync(_part);
          return CreatedAtAction(nameof(GetPartsByID),new { partnum = partNo ,Controller= "EwclaimPartMaster" },partNo );
          //  return CreatedAtAction(nameof(GetPartsByID), new { partnum = partNo, Controller = "EwclaimPartMaster" }, _part);

        }


        [HttpPut("{partid}")]
        public async Task<ActionResult> UpdateNewPart([FromRoute] int partid, [FromBody] EwclaimPartMaster _part)
        {
            /*
            //Method 1 - with all fields
           await _IEwclaimPartMasterRepository.UpdateAsync(partid, _part);
            return  Ok();
            */

            //Method 2 - Just Map
            if (_part == null)
                return BadRequest("Invalid data.");

            var updated = await _IEwclaimPartMasterRepository.UpdatePartAsync(partid, _part);

            if (!updated)
                return NotFound($"No part found with ID = {partid}");

            return Ok("Part updated successfully.");


        }

        [HttpPatch("{partid}")]
        public async Task<ActionResult> UpdateNewPartPatch([FromRoute] int partid, [FromBody] JsonPatchDocument _part)
        {
            await _IEwclaimPartMasterRepository.UpdatePatchAsync(partid, _part);
            return Ok();
        }


        [HttpDelete("{partid}")]
        public async Task<ActionResult> DeletePart([FromRoute] int partid)
        {
            await _IEwclaimPartMasterRepository.DeleteAsync(partid);
            return Ok();
        }
    }
   
    
}
