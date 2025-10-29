using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using System.Diagnostics.Eventing.Reader;
using WarrantyAPITest.Data;
using WarrantyAPITest.Interfaces;
using WarrantyAPITest.Models;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;
using AutoMapper;

namespace WarrantyAPITest.Repository
{
    public class EwclaimPartMasterRepository : IEwclaimPartMasterRepository
    {
        private readonly GaponlineDemo1Context _context;
        private readonly IMapper _mapper;

        public EwclaimPartMasterRepository(GaponlineDemo1Context context,IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EwclaimPartMaster>> GetAllAsync()
        {
            //throw new NotImplementedException();
            /*
            var records = await _context.EwclaimPartMasters.Select(x=> new EwclaimPartMaster()
            {
             PartId=x.PartId,    
             PartNumber =x.PartNumber,
             PartDescription = x.PartDescription,
             PartType = x.PartType,
             DealerCode = x.DealerCode,
             MakeCode = x.PartNumber,
             CreatedDate = x.CreatedDate,
             CreatedBy = x.CreatedBy,
             ModifiedDate = x.ModifiedDate,
             ModifiedBy = x.ModifiedBy
            }
            ).ToListAsync();
            return records;
            */

            var records = await _context.EwclaimPartMasters.ToListAsync();
            return _mapper.Map<List<EwclaimPartMaster>>(records);


        }

        //public async Task<IEnumerable<EwclaimPartMaster>> GetAllAsync()
        //{
        //    //throw new NotImplementedException();
        //    var records= await _context.EwclaimPartMasters.ToListAsync();
        //}
      

      
     

        public async Task<EwclaimPartMaster?> GetByIdAsync(int  _partnumber)
        {
            //throw new NotImplementedException();
            /*
              var records = await _context.EwclaimPartMasters.Where(x => x.PartId == _partnumber).Select(x => new EwclaimPartMaster()
              {
                  PartId = x.PartId,
                  PartNumber = x.PartNumber,
                  PartDescription = x.PartDescription,
                  PartType = x.PartType,
                  DealerCode = x.DealerCode,
                  MakeCode = x.PartNumber,
                  CreatedDate = x.CreatedDate,
                  CreatedBy = x.CreatedBy,
                  ModifiedDate = x.ModifiedDate,
                  ModifiedBy = x.ModifiedBy
              }
           ).FirstOrDefaultAsync();
              return records;
              */

            var records = await _context.EwclaimPartMasters.FindAsync(_partnumber);
            return _mapper.Map<EwclaimPartMaster>(records);


        }


        public async Task<int> AddAsync(EwclaimPartMaster _EwclaimPartMasterModel)
        {
            //throw new NotImplementedException();
            /*
            var _EwclaimPartMaster = new EwclaimPartMaster()
            {
                PartNumber = _EwclaimPartMasterModel.PartNumber,
                PartDescription = _EwclaimPartMasterModel.PartDescription,
                PartType = _EwclaimPartMasterModel.PartType,
                DealerCode = _EwclaimPartMasterModel.DealerCode,
                MakeCode = _EwclaimPartMasterModel.PartNumber,
                CreatedDate = _EwclaimPartMasterModel.CreatedDate,
                CreatedBy = _EwclaimPartMasterModel.CreatedBy,
                ModifiedDate = _EwclaimPartMasterModel.ModifiedDate,
                ModifiedBy = _EwclaimPartMasterModel.ModifiedBy
            };
            _context.EwclaimPartMasters.Add(_EwclaimPartMaster);
            await _context.SaveChangesAsync();
            return _EwclaimPartMaster.PartId;
            */

            var _EwclaimPartMaster = _mapper.Map<EwclaimPartMaster>(_EwclaimPartMasterModel);
            await _context.SaveChangesAsync();
            return _EwclaimPartMaster.PartId;


        }

        //public Task UpdateAsync(int partID)
        //{
        //    // throw new NotImplementedException();
        //    EwclaimPartMaster _EwclaimPartMaster = GetByIdAsync(partID);

        //}
        public async Task UpdateAsync( int PartID, EwclaimPartMaster _EwclaimPartMasterModel)
        {

            /*
             //Method 1 (2 db works : 1 - fetch ;2- update)
            var existPartMaster= await _context.EwclaimPartMasters.FindAsync(PartID);
            if (existPartMaster != null) {
                existPartMaster.PartId = _EwclaimPartMasterModel.PartId;
                existPartMaster.PartNumber = _EwclaimPartMasterModel.PartNumber;
                existPartMaster.PartDescription = _EwclaimPartMasterModel.PartDescription;
                existPartMaster.PartType = _EwclaimPartMasterModel.PartType;
                existPartMaster.DealerCode = _EwclaimPartMasterModel.DealerCode;
                existPartMaster.MakeCode = _EwclaimPartMasterModel.MakeCode;
                existPartMaster.CreatedDate = _EwclaimPartMasterModel.CreatedDate;
                existPartMaster.CreatedBy = _EwclaimPartMasterModel.CreatedBy;
                existPartMaster.ModifiedDate = _EwclaimPartMasterModel.ModifiedDate;
                existPartMaster.ModifiedBy = _EwclaimPartMasterModel.ModifiedBy;
                await _context.SaveChangesAsync();
            }
            */
            //Method 2 (1 db works : 1- update)
            var _EwclaimPartMaster = new EwclaimPartMaster()
            {
                PartId= PartID,
                PartNumber = _EwclaimPartMasterModel.PartNumber,
                PartDescription = _EwclaimPartMasterModel.PartDescription,
                PartType = _EwclaimPartMasterModel.PartType,
                DealerCode = _EwclaimPartMasterModel.DealerCode,
                MakeCode = _EwclaimPartMasterModel.MakeCode,
                CreatedDate = _EwclaimPartMasterModel.CreatedDate,
                CreatedBy = _EwclaimPartMasterModel.CreatedBy,
                ModifiedDate = _EwclaimPartMasterModel.ModifiedDate,
                ModifiedBy = _EwclaimPartMasterModel.ModifiedBy
            };
            _context.EwclaimPartMasters.Update(_EwclaimPartMaster);
            await _context.SaveChangesAsync();
          

        }
        //Learn Mapper
        public async Task<bool> UpdatePartAsync(int partId, EwclaimPartMaster model)
        {
            var existing = await _context.EwclaimPartMasters.FirstOrDefaultAsync(p => p.PartId == partId);
            if (existing == null)
                return false;

            // Map updated values onto the existing entity
            _mapper.Map(model, existing);

            // Save changes
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdatePatchAsync(int partId, JsonPatchDocument _EwclaimPartMaster) { 
           var existPartMaster = await _context.EwclaimPartMasters.FindAsync(partId);
            if (existPartMaster != null) {
                _EwclaimPartMaster.ApplyTo(existPartMaster);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int Partid) {
            var existPartMaster = new EwclaimPartMaster() { PartId = Partid };
            _context.EwclaimPartMasters.Remove(existPartMaster);
            await _context.SaveChangesAsync();
        }
      


    }
}
