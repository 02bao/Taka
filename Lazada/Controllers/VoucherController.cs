﻿using Lazada.Interface;
using Lazada.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lazada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRepository _voucherRepository;

        public VoucherController(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        [HttpPost("AddNewVoucher")]
        public IActionResult AddNewVoucher(long shopid , Voucher_Add addvoucher, DateTime expiredate, long productvoucherid)
        {
            bool tmp = _voucherRepository.AddnewVoucher(shopid, addvoucher, expiredate, productvoucherid);
            if(tmp)
            {
                return Ok("Add Voucher Successfully");
            }
            return BadRequest("Error");
        }

        [HttpGet("GetVoucherByCartID")]
        public IActionResult GetVoucherByCartID(long cartid)
        {
            var tmp = _voucherRepository.GetVoucherbyCartId(cartid);
            return Ok(tmp);
        }

        [HttpGet("GetVoucherByShopId")]
        public IActionResult GetVoucherByShopId(long shopid)
        {
            var tmp = _voucherRepository.GetVoucherbyShopid(shopid);
            return Ok(tmp);
        }

        [HttpGet("WareHouseShopVoucher")]
        public IActionResult WareHouseShopVoucher(long userid)
        {
            var tmp = _voucherRepository.WareHouseShopVoucher(userid);
            return Ok(tmp);
        }

        [HttpPost("WareShop_save")]
        public IActionResult WareShop_save(long userid , long voucherid)
        {
            bool tmp = _voucherRepository.warehouse_save(userid, voucherid);
            if(tmp)
            {
                return Ok("Successfully");
            }
            return BadRequest("Error");
        }
    }
}
