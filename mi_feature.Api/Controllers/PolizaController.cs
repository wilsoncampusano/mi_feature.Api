using MediatR;
using Microsoft.AspNetCore.Mvc;
using App.Queries;
using App.DTOs;
using mi_feature.Api.Controllers.Helpers;
using System.ComponentModel.DataAnnotations;

namespace mi_feature.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PolizaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PolizaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(nameof(ObtenerPoliza))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<PolizaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<PolizaDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<PolizaDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<PolizaDto>))]
        public async Task<IActionResult> ObtenerPoliza([FromQuery, Required]  string poliza)
        {
            var result = await _mediator.Send(new ObtenerPolizaQuery { Poliza = poliza });

            return StatusCode(result.StatusCode, result);
        }
    }
}
