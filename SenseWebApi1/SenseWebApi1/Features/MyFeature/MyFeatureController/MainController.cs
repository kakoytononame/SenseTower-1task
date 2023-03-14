﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.Features.MyFeature.Commands.EventsCommands;
using SenseWebApi1.Context;
using System.Reflection.Metadata;
using System.Threading;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        

        public MainController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        /// <summary>
        /// Создание события
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Пример входных данных:
        ///
        ///     POST /events
        ///     {
        ///        "eventId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///        "beginning": "2023-03-14T16:52:06.478Z",Тип данных:DateTime
        ///        "end": "2023-03-14T16:52:06.478Z",Тип данных:DateTime
        ///        "eventName": "string",Тип данных:String
        ///        "description": "string",Тип данных:String
        ///        "imageId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///        "areaId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Возвращает id добавленного события </response>
        [HttpPost("events")]

        public async Task<IActionResult> CreateEvent(EventDto eventDto)
        {
            var eventCreateCommand = _mapper.Map<EventCreateCommand>(eventDto);
            var result=await _mediator.Send(eventCreateCommand);
            return Ok(result);
        }
        /// <summary>
        /// Изменение события
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Пример входных данных:
        ///
        ///     PUT /events/{eventId}
        ///     {
        ///        "eventId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///        "beginning": "2023-03-14T16:52:06.478Z",Тип данных:DateTime
        ///        "end": "2023-03-14T16:52:06.478Z",Тип данных:DateTime
        ///        "eventName": "string",Тип данных:String
        ///        "description": "string",Тип данных:String
        ///        "imageId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///        "areaId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",Тип данных:Guid
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Возвращает данные об измененном событии </response>
        [HttpPut("events/{eventId}")]

        public async Task<IActionResult> ChangeEvent(EventDto eventDto)
        {
            var eventUpdateCommand = _mapper.Map<EventUpdateCommand>(eventDto);
            var result=await _mediator.Send(eventUpdateCommand);
            return Ok(result);
        }
        /// <summary>
        /// Удаление события
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Пример входных данных:
        ///
        ///     PUT /events/{eventId}
        ///     eventId Тип данных:Guid
        ///
        /// </remarks>
        /// <response code="200">Возвращает id удаленного события</response>
        [HttpDelete("events/{eventId}")]

        public async Task<IActionResult> DeleteEvent(Guid eventId)
        {
            _mediator.Send(new EventDeleteCommand() {EventId=eventId });
            return Ok();
        }

        /// <summary>
        /// Получение событий из базы данных
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Возвращает json строку с данными о событиях </response>
        [HttpGet("events")]
        public async Task<IActionResult> GetEvents()
        {
            
            
            var result =await _mediator.Send(new GetEventCommand());
            
            return Ok(result);
        }
        

        

    }
}
