using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarrantyAPITest.Models;

public partial class EwclaimPartMaster
{
    public int PartId { get; set; }
    [Required]
    public string PartNumber { get; set; }

    public string? PartDescription { get; set; }

    public string? PartType { get; set; }

    public string? DealerCode { get; set; }

    public string? MakeCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public short? ModifiedBy { get; set; }

   
}
