﻿using Lazada.Interface;
using Lazada.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lazada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost("AddToCart")]
        public IActionResult AddtoCart(long userId, CartItem_add cartItem_Add)
        {
            bool tmp = _cartRepository.AddtoCart(userId, cartItem_Add);
            if(tmp)
            {
                return Ok("Add Successfully");
            }
            return BadRequest("Error");
        }

        [HttpGet("GetCartByUserId")]
        public IActionResult GetCartByUserId(long userId)
        {
            var carts = _cartRepository.GetCartByUserId(userId);
            return Ok(carts);
        }

        [HttpPost("IncreaCartItem")]
        public IActionResult IncreaCartItem(long cartItemId)
        {
            bool tmp = _cartRepository.IncreaCartItem(cartItemId);
            if(tmp)
            {
                return Ok("Increase Successfully");
            }
            return BadRequest("Error");
        }

        [HttpPost("DescreaseCartItem")]
        public IActionResult DescreaseCartItem(long cartItemId)
        {
            bool tmp = _cartRepository.descreaCartItem(cartItemId);
            if(tmp)
            {
                return Ok("Descrease successfully");
            }
            return BadRequest("Error");
        }

        [HttpDelete("DeleteCartItem")]
        public IActionResult DeleteCartItem( long cartItemId)
        {
            bool tmp = _cartRepository.RemoveCartItem( cartItemId);
            if( tmp )
            {
                return Ok("Delete Successfully");
            }
            return BadRequest("Error");
        }
    }
}
