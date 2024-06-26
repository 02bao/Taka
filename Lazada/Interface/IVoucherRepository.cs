﻿using Lazada.Models;

namespace Lazada.Interface
{
    public interface IVoucherRepository
    {
        bool AddnewVoucher(long shopid, Voucher_Add addvoucher, DateTime expiredate, long productvoucherid);
        List<Voucher_Product> GetVoucherbyCartId(long cartid);
        List<Voucher_Product> GetVoucherbyShopid(long shopid);
        List<Voucher_Product> WareHouseShopVoucher(long userid);
        bool warehouse_save(long userid, long voucherid);
    }
}
