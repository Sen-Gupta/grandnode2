using Grand.Module.Api.DTOs.Common;

using MediatR;

namespace Grand.Module.Api.Commands.Models.Store;

public class UpdateStoreCommand : IRequest<StoreDto>
{
    public StoreDto Model { get; set; }
}