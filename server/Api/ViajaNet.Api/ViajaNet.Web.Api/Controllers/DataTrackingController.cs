﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViajaNet.TrackingData.Domain.Commands;

namespace ViajaNet.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTrackingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DataTrackingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/DataTracking
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //_mediator.Send()
            return new string[] { "value1", "value2" };
        }

        // POST: api/DataTracking
        [HttpPost]
        public void Post([FromBody] DataTrackingCreateCommand command)
        {
            _mediator.Publish(command);
        }
    }
}