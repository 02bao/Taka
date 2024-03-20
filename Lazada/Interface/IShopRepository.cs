﻿using Lazada.Models;

namespace Lazada.Interface
{
    public interface IShopRepository
    {
        ICollection<Shop> GetList();
        Shop GetShopid(long id);
        bool CreateShop(Shop_Create shop);
        bool UpdateShop(Shop shop);
        bool DeleteShop(long id);
    }
}
