using System;
using System.Collections.Generic;

namespace WarrantyAPITest.Models;

public partial class EwclaimSubmissionDetailsApi
{
    public int SlNumber { get; set; }

    public int? SubmissionId { get; set; }

    public string? PartNumber { get; set; }

    public string? PartDescription { get; set; }

    public string? DamageCode { get; set; }

    public decimal PartsCost { get; set; }

    public string? PartsGoodWillType { get; set; }

    public decimal PartsGoodWill { get; set; }

    public string? PartsDiscountType { get; set; }

    public decimal PartsDiscount { get; set; }

    public decimal PartsQuoted { get; set; }

    public decimal LabourCost { get; set; }

    public string? LabourGoodWillType { get; set; }

    public decimal LabourGoodWill { get; set; }

    public string? LabourDiscountType { get; set; }

    public decimal LabourDiscount { get; set; }

    public decimal LabourQuoted { get; set; }

    public string? Remarks { get; set; }

    public string? IsTemporaryRejected { get; set; }

    public int PartType { get; set; }

    public string? PartParent { get; set; }
}
