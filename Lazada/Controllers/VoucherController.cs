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
        public IActionResult AddNewVoucher(long shopid , Voucher_Add addvoucher)
        {
            bool tmp = _voucherRepository.AddnewVoucher(shopid, addvoucher);
            if(tmp)
            {
                return Ok("Add Voucher Successfully");
            }
            return BadRequest("Error");
        }

    }
}
