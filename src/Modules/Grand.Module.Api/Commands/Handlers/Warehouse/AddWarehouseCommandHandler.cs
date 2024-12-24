using Grand.Business.Core.Interfaces.Checkout.Shipping;
using Grand.Business.Core.Interfaces.Common.Seo;
using Grand.Business.Core.Interfaces.Common.Stores;
using Grand.Module.Api.Commands.Models.Store;
using Grand.Module.Api.Commands.Models.Warehouse;
using Grand.Module.Api.DTOs.Common;
using Grand.Module.Api.DTOs.Shipping;
using Grand.Module.Api.Extensions;

using MediatR;

namespace Grand.Module.Api.Commands.Handlers.Warehouse;

public class AddWarehouseCommandHandler : IRequestHandler<AddWarehouseCommand, WarehouseDto>
{
    private readonly IWarehouseService _warehouseService;
    public AddWarehouseCommandHandler(
        IWarehouseService warehouseService,
        ISlugService slugService,
        ISeNameService seNameService)
    {
        _warehouseService = warehouseService;
        
    }

    public async Task<WarehouseDto> Handle(AddWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = request.Model.ToEntity();
        await _warehouseService.InsertWarehouse(warehouse);
        return warehouse.ToModel();
    }
}