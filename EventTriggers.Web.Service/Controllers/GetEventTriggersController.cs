using EventTriggers.DataPersistence;
using EventTriggers.Models.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTriggers.Web.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetEventTriggersController : ControllerBase
    {
        public GetEventTriggersController(IEventTriggersRepository eventTriggersRespository,
            ILogger<GetEventTriggersController> logger)
        {
            _eventTriggersRespository = eventTriggersRespository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _eventTriggersRespository.GetAll();
        }

        [HttpGet("{eventTriggerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Event>> Get(Guid eventTriggerId)
        {
            var result = await _eventTriggersRespository.GetEventTrigger(eventTriggerId);

            if (result == null) return NotFound();

            return Ok(result);
        }

        /*[HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> Post([FromBody] OrderCreateUpdate orderRequest)
        {
            var order = new Order()
            {
                Amount = orderRequest.Amount,
                UserId = orderRequest.UserId
            };

            var result = await ordersRepository.CreateOrder(order);

            if (result == null) return BadRequest();

            return StatusCode(201, result);
        }*/

        private readonly ILogger<GetEventTriggersController> _logger;
        private readonly IEventTriggersRepository _eventTriggersRespository;
    }
}