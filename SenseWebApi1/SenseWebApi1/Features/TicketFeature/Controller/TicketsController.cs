using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SC.Internship.Common.ScResult;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.Features.MyFeature.Commands.TicketsCommand;
using SenseWebApi1.Features.TicketFeature.Commands.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.Controller
{
    [ApiController]
    [Route("api")]
    public class TicketsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public TicketsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        /// <summary>
        /// Добавить бесплатные билеты
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Пример входных данных:
        ///
        ///     POST /tickets
        ///     {
        ///        "eventId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///        "countoftickets": "10",Тип данных:int
        ///       
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Возвращает bool добавленны билеты </response>
        /// <response code="401">Возвращает unauthorized </response>
        /// <response code="500">Ошибка сервера </response>
        [HttpPost("tickets")]
        public async Task<IActionResult> AddFreeTickets(Guid EventId, int countoftickets)
        {

            var result = await _mediator.Send(new AddFreeTicketsCommand() {EventId=EventId, countoftickets = countoftickets });
            return Ok(new ScResult<bool>()
            {
                Result=result
            });
        }
        /// <summary>
        /// Дать пользователю билет
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Пример входных данных:
        ///
        ///     POST /tickets/{ticketId}
        ///     {
        ///        "eventId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///        "ticketId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///       
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Возвращает bool добавленны билеты </response>
        /// <response code="401">Возвращает unauthorized </response>
        /// <response code="500">Ошибка сервера </response>
        [HttpPut("tickets/{ticketId}")]

        public async Task<IActionResult> GiveTicketForUser(Guid ticketId,Guid OwnerId)
        {
            var result = await _mediator.Send(new GiveTicketForUserCommand() { TicketId = ticketId, OwnerId = OwnerId });
            return Ok(new ScResult<Guid>()
            {
                Result=result
            });
        }
        /// <summary>
        /// Проверить билет у пользователя
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Пример входных данных:
        ///
        ///     POST /tickets
        ///     {
        ///        "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///        "ticketId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///       
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Возвращает bool добавленны билеты </response>
        /// <response code="401">Возвращает unauthorized </response>
        /// <response code="500">Ошибка сервера </response>
        [HttpGet("tickets")]

        public async Task<IActionResult> CheckTicketForUser(Guid EventId,Guid UserId)
        {
            var result = await _mediator.Send(new CheckTicketForUserCommand() { EventId = EventId, OwnerId = UserId });
            return Ok(new ScResult<bool>()
            {
                Result = result
            });
        }
    }
}
