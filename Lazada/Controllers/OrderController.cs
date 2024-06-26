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

        [HttpPost("AddtoOrder")]
        public IActionResult AddtoOrder(long userid, List<long> cartitemids, long voucherid)
        {
            bool tmp = _orderRepository.AddtoOrder(userid, cartitemids, voucherid);
            if(tmp)
            {
                return Ok("Add Order successfully");
            }
            return BadRequest("Error");
        }

        [HttpGet("GetOrderByUserId")]
        public IActionResult GetOrderByUserId(long userId)
        {
            var tmp = _orderRepository.GetOrderbyUserId(userId);
            return Ok(tmp);
        }

        [HttpDelete("CancleOrder")]
        public IActionResult CancleOrder(long orderid)
        {
            bool tmp = _orderRepository.CancleOrder(orderid);
            if( tmp )
            {
                return Ok("Cancle Successfully");
            }
            return BadRequest("Erorr");
        }

        [HttpGet("GetOrderbyShopid")]
        public IActionResult GetOrderbyShopid(long shopid)
        {
            var tmp = _orderRepository.GetOrderbyShopid(shopid);
            return Ok(tmp);
        }

    }
}
