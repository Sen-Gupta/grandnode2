using Grand.Module.Api.DTOs.Catalog;
using Grand.Module.Api.DTOs.Common;

using MediatR;

namespace Grand.Module.Api.Commands.Models.Store;

public class AddStoreCommand : IRequest<StoreDto>
{
    public StoreDto Model { get; set; }
}