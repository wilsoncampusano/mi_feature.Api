using MediatR;
using Microsoft.AspNetCore.Mvc;
using App.Queries;
using App.DTOs;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PolizaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPoliza(string poliza)
        {
                var result = await _mediator.Send(new ObtenerPolizaQuery { Poliza = poliza });

                return result.StatusCode switch
                {
                    200 => Ok(result.Data),
                    404 => NotFound(new { message = result.Message }),
                    400 => BadRequest(new { message = result.Message }), 
                    500 => StatusCode(500, new { message = result.Message }),
                    _ => StatusCode(500, new { message = "Error desconocido." })
                };
        }
    }
}
