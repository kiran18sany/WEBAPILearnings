using Microsoft.AspNetCore.JsonPatch;
using WarrantyAPITest.Models;

namespace WarrantyAPITest.Interfaces
{
    public interface IEwclaimPartMasterRepository
    {

        Task<List<EwclaimPartMaster>> GetAllAsync();
        Task<EwclaimPartMaster?> GetByIdAsync(int _partnumber);
        Task<int> AddAsync(EwclaimPartMaster _EwclaimPartMasterModel);
        Task UpdateAsync(int PartID, EwclaimPartMaster _part);
        Task DeleteAsync(int Partid);      
        Task UpdatePatchAsync(int partid, JsonPatchDocument _EwclaimPartMaster);
    }
}