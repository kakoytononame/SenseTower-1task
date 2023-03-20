using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SC.Internship.Common.ScResult;
using SenseWebApi1.Features.TicketFeature.AddFreeTickets;
using SenseWebApi1.Features.TicketFeature.CheckTicketForUser;
using SenseWebApi1.Features.TicketFeature.GetTicket;
using SenseWebApi1.Features.TicketFeature.GiveTicketForUser;

namespace SenseWebApi1.Features.TicketFeature
{
    [ApiController]
    [Route("api")]
    public class TicketsController : ControllerBase
    {
        // ReSharper disable once NotAccessedField.Local
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
        public async Task<IActionResult> AddFreeTickets(Guid eventId, int countoftickets)
        {

            var result = await _mediator.Send(new AddFreeTicketsCommand() { EventId = eventId, Countoftickets = countoftickets });
            return Ok(new ScResult<bool>()
            {
                Result = result
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
        ///         "ticketId": "8299f9f5-6176-4595-9004-bd01beafeb25",
        ///         "ownerId": "f4d26a57-0725-4796-82bf-2be457bbfcd4",
        ///         "place": "4"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Возвращает bool добавленны билеты </response>
        /// <response code="401">Возвращает unauthorized </response>
        /// <response code="500">Ошибка сервера </response>
        [HttpPut("tickets/{ticketId}")]

        public async Task<IActionResult> GiveTicketForUser( Guid ticketId, Guid ownerId,int place)
        {
            var result = await _mediator.Send(new GiveTicketForUserCommand() { TicketId = ticketId, OwnerId = ownerId, Place = place});
            return Ok(new ScResult<Guid>()
            {
                Result = result
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
        /// <response code="200">Возвращает bool  </response>
        /// <response code="401">Возвращает unauthorized </response>
        /// <response code="500">Ошибка сервера </response>
        [HttpGet("tickets")]

        public async Task<IActionResult> CheckTicketForUser(Guid eventId, Guid userId)
        {
            var result = await _mediator.Send(new CheckTicketForUserCommand() { EventId = eventId, OwnerId = userId });
            return Ok(new ScResult<bool>()
            {
                Result = result
            });
        }

        [HttpGet("tickets/gettickets")]

        public async Task<IActionResult> GetTickets(Guid eventId)
        {
            var result = await _mediator.Send(new GetTicketsCommand() { EventId = eventId });
            return Ok(new ScResult<List<Ticket>>()
            {
                Result = result
            });
        }
    }
}
