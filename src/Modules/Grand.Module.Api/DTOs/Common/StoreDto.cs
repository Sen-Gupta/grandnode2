using Grand.Module.Api.Models;

using MassTransit;

namespace Grand.Module.Api.DTOs.Common;

public class StoreDto : BaseApiEntityModel
{

    public string Name { get; set; }
    public string Shortcut { get; set; }
    public string Url { get; set; }
    public bool SslEnabled { get; set; } = true;
    public string DefaultWarehouseId { get; set; }
    public int DisplayOrder { get; set; }
    public string CompanyName { get; set; }
    public string CompanyPhoneNumber { get; set; }
    public string CompanyEmail { get; set; }
    public string CompanyAddress { get; set; }
    
}