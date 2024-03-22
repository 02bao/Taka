﻿using Lazada.Interface;
using Lazada.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lazada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("AddToOrder")]
        public IActionResult AddToOrder( long userId, long cartitemId)
        {
            bool tmp = _orderRepository.AddtoOrder(userId, cartitemId);
            if(tmp)
            {
                return Ok("Add Successfully");
            }
            return BadRequest("Error");
        }

        [HttpGet("GetOrderByUserId")]
        public IActionResult GetOrderByUserId(long userId)
        {
            var tmp = _orderRepository.GetOrderByUserId(userId);
            return Ok(tmp);
        }
    }
}