﻿using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsConttroller : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse response = await Mediator.Send(createBrandCommand);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(getListBrandQuery);
            return Ok(response);

        }
    }
}
