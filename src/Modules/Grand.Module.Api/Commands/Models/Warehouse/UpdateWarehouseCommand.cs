using Grand.Module.Api.DTOs.Catalog;
using Grand.Module.Api.DTOs.Shipping;

using MediatR;

namespace Grand.Module.Api.Commands.Models.Catalog;

public class UpdateWarehouseCommand : IRequest<WarehouseDto>
{
    public WarehouseDto Model { get; set; }
}