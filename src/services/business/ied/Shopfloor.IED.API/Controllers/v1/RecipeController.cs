﻿using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.Recipes;
using Shopfloor.IED.Application.Parameters.Recipes;
using Shopfloor.IED.Application.Query.Recipes;
using Shopfloor.IED.Application.Query.RecipeSyncWFXs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RecipeController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RecipeParameter filter)
        {
            return Ok(await Mediator.Send(new GetRecipesQuery()
            {
                DyeingTBRecipeId = filter.DyeingTBRecipeId,
                RecipeNo = filter.RecipeNo,
                JobDate = filter.JobDate,
                TCFNO = filter.TCFNO,
                Style = filter.Style,
                Description = filter.Description,
                FabricCode = filter.FabricCode,
                FabricName = filter.FabricName,
                Color = filter.Color,
                LotNo = filter.LotNo,
                RollKg = filter.RollKg,
                Speed = filter.Speed,
                NozzleA = filter.NozzleA,
                NozzleB = filter.NozzleB,
                Method = filter.Method,
                LAB = filter.LAB,
                InCharge = filter.InCharge,
                Manager = filter.Manager,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetRecipeQuery { Id = id }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("syncwfx/{dyeingRecipeId}")]
        public async Task<IActionResult> GetRecipeSyncWFX(int dyeingRecipeId)
        {
            return Ok(await Mediator.Send(new GetRecipeSyncWFXQuery { DyeingTBRecipeId = dyeingRecipeId }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateRecipeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRecipeCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            return Ok(await Mediator.Send(new SoftDeleteRecipeCommand { Id = id }));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRecipeCommand { Id = id }));
        }
    }
}