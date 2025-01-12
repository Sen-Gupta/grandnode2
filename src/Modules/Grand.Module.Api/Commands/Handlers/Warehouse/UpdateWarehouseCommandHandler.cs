using Grand.Business.Core.Interfaces.Checkout.Shipping;
using Grand.Business.Core.Interfaces.Common.Seo;
using Grand.Module.Api.Commands.Models.Catalog;
using Grand.Module.Api.DTOs.Shipping;
using Grand.Module.Api.Extensions;

using MediatR;

namespace Grand.Module.Api.Commands.Handlers.Warehouse;

public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, WarehouseDto>
{
    private readonly IWarehouseService _warehouseService;
    public UpdateWarehouseCommandHandler(
        IWarehouseService warehouseService,
        ISlugService slugService,
        ISeNameService seNameService)
    {
        _warehouseService = warehouseService;
    }

    public async Task<WarehouseDto> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var brand = await _warehouseService.GetWarehouseById(request.Model.Id);
        brand = request.Model.ToEntity(brand);
        await _warehouseService.UpdateWarehouse(brand);
        return brand.ToModel();
    }
}