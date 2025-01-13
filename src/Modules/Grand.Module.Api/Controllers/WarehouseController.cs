﻿using Grand.Business.Core.Interfaces.Common.Security;
using Grand.Domain.Permissions;
using Grand.Domain.Shipping;
using Grand.Module.Api.Attributes;
using Grand.Module.Api.Commands.Models.Catalog;
using Grand.Module.Api.Commands.Models.Warehouse;
using Grand.Module.Api.DTOs.Shipping;
using Grand.Module.Api.Infrastructure.Extensions;
using Grand.Module.Api.Queries.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Net;

namespace Grand.Module.Api.Controllers;

public class WarehouseController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IPermissionService _permissionService;

    public WarehouseController(IMediator mediator, IPermissionService permissionService)
    {
        _mediator = mediator;
        _permissionService = permissionService;
    }

    [EndpointDescription("Get entity from Warehouse by key")]
    [EndpointName("GetWarehouseById")]
    [HttpGet("{key}")]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseDto))]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get([FromRoute] string key)
    {
        if (!await _permissionService.Authorize(PermissionSystemName.ShippingSettings)) return Forbid();

        var warehouse = await _mediator.Send(new GetGenericQuery<WarehouseDto, Warehouse>(key));
        if (!warehouse.Any()) return NotFound();

        return Ok(warehouse.FirstOrDefault());
    }

    [EndpointDescription("Get entities from Warehouse")]
    [EndpointName("GetWarehouses")]
    [HttpGet]
    [EnableQuery]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WarehouseDto>))]
    public async Task<IActionResult> Get()
    {
        if (!await _permissionService.Authorize(PermissionSystemName.ShippingSettings)) return Forbid();

        return Ok(await _mediator.Send(new GetGenericQuery<WarehouseDto, Warehouse>()));
    }


    [EndpointDescription("Add new entity to Warehouse")]
    [EndpointName("InsertWarehouse")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseDto))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post([FromBody] WarehouseDto model)
    {
        if (!await _permissionService.Authorize(PermissionSystemName.Brands)) return Forbid();
        model = model.Bind();
        model = await _mediator.Send(new AddWarehouseCommand { Model = model });
        return Ok(model);
    }

    [EndpointDescription("Update entity in Warehouse")]
    [EndpointName("UpdateWarehouse")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseDto))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Put([FromBody] WarehouseDto model)
    {
        if (!await _permissionService.Authorize(PermissionSystemName.Brands)) return Forbid();

        model = await _mediator.Send(new UpdateWarehouseCommand { Model = model });
        return Ok(model);
    }
}