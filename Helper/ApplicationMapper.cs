using AutoMapper;
using WarrantyAPITest.Models;
   

namespace WarrantyAPITest.Helper
{
    public class ApplicationMapper :Profile
    {
        public ApplicationMapper()
        {
            CreateMap<EwclaimPartMaster, EwclaimPartMaster>();
        }
    }
}
