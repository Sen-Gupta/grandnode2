﻿using Grand.Business.Core.Interfaces.Common.Security;
using Grand.Domain.Permissions;
using Grand.Domain.Stores;
using Grand.Module.Api.Attributes;
using Grand.Module.Api.Commands.Models.Store;
using Grand.Module.Api.DTOs.Common;
using Grand.Module.Api.Infrastructure.Extensions;
using Grand.Module.Api.Queries.Models.Common;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using System.Net;

namespace Grand.Module.Api.Controllers;

public class StoreController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IPermissionService _permissionService;

    public StoreController(IMediator mediator, IPermissionService permissionService)
    {
        _mediator = mediator;
        _permissionService = permissionService;
    }

    [EndpointDescription("Get entity from Store by key")]
    [EndpointName("GetStoreById")]
    [HttpGet("{key}")]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StoreDto))]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get([FromRoute] string key)
    {
        if (!await _permissionService.Authorize(PermissionSystemName.Stores)) return Forbid();

        var store = await _mediator.Send(new GetGenericQuery<StoreDto, Store>(key));
        if (!store.Any()) return NotFound();

        return Ok(store.FirstOrDefault());
    }

    [EndpointDescription("Get entities from Store")]
    [EndpointName("GetStores")]
    [HttpGet]
    [EnableQuery]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StoreDto>))]
    public async Task<IActionResult> Get()
    {
        if (!await _permissionService.Authorize(PermissionSystemName.Stores)) return Forbid();

        return Ok(await _mediator.Send(new GetGenericQuery<StoreDto, Store>()));
    }

    [EndpointDescription("Add new entity to Store")]
    [EndpointName("InsertStore")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StoreDto))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post([FromBody] StoreDto model)
    {
        if (!await _permissionService.Authorize(PermissionSystemName.Brands)) return Forbid();
        model = model.Bind(Request);
        model = await _mediator.Send(new AddStoreCommand { Model = model });
        return Ok(model);
    }

    [EndpointDescription("Update entity in Store")]
    [EndpointName("UpdateStore")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StoreDto))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Put([FromBody] StoreDto model)
    {
        if (!await _permissionService.Authorize(PermissionSystemName.Brands)) return Forbid();

        model = await _mediator.Send(new UpdateStoreCommand { Model = model });
        return Ok(model);
    }
}