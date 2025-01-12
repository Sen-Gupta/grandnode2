using Grand.Business.Core.Interfaces.Common.Stores;
using Grand.Module.Api.Commands.Models.Store;
using Grand.Module.Api.DTOs.Common;
using Grand.Module.Api.Extensions;

using MediatR;

namespace Grand.Module.Api.Commands.Handlers.Store;

public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, StoreDto>
{
    private readonly IStoreService _storeService;
   
    public UpdateStoreCommandHandler(
        IStoreService storeService)
    {
        _storeService = storeService;
    }

    public async Task<StoreDto> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        var store = request.Model.ToEntity();
        await _storeService.UpdateStore(store);
        return store.ToModel();
    }
}