using System;
using System.Collections.Generic;

namespace WarrantyAPITest.Models;

public partial class EwclaimSubmissionHeaderApi
{
    public int SubmissionId { get; set; }

    public DateTime? SubmissionDate { get; set; }

    public string? CountryCode { get; set; }

    public string? DealerCode { get; set; }

    public string? DealerLocationCode { get; set; }

    public string? BookletName { get; set; }

    public int BookletNumber { get; set; }

    public string? Vinnumber { get; set; }

    public string? FirstName { get; set; }

    public string? NumberPlate { get; set; }

    public int ClaimKm { get; set; }

    public DateTime? FailureDate { get; set; }

    public string? ServiceCheck { get; set; }

    public string? LastServicedBy { get; set; }

    public DateTime? LastServiceDate { get; set; }

    public int LastServiceKm { get; set; }

    public string? CustomerComplaint { get; set; }

    public string? DefectAnalysis { get; set; }

    public int NoofItems { get; set; }

    public int UserId { get; set; }

    public int Status { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? GappolicyNo { get; set; }

    public int GappolicySerialNo { get; set; }

    public int CategoryId { get; set; }

    public string? RepairerReferenceNo { get; set; }
}
