using Grand.Module.Api.DTOs.Shipping;

using MediatR;

namespace Grand.Module.Api.Commands.Models.Warehouse;

public class AddWarehouseCommand : IRequest<WarehouseDto>
{
    public WarehouseDto Model { get; set; }
}