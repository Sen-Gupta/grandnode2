using Grand.Business.Core.Interfaces.Common.Stores;
using Grand.Module.Api.Commands.Models.Store;
using Grand.Module.Api.DTOs.Common;
using Grand.Module.Api.Extensions;

using MediatR;

namespace Grand.Module.Api.Commands.Handlers.Store;

public class AddStoreCommandHandler : IRequestHandler<AddStoreCommand, StoreDto>
{
    private readonly IStoreService _storeService;
   
    public AddStoreCommandHandler(
        IStoreService storeService)
    {
        _storeService = storeService;
    }

    public async Task<StoreDto> Handle(AddStoreCommand request, CancellationToken cancellationToken)
    {
        var store = request.Model.ToEntity();

        await _storeService.InsertStore(store);
        //request.Model.SeName = await _seNameService.ValidateSeName(store, request.Model.SeName, store.Name, true);
        //store.SeName = request.Model.SeName;
        await _storeService.UpdateStore(store);
        //await _slugService.SaveSlug(store, request.Model.SeName, "");
        return store.ToModel();
    }
}