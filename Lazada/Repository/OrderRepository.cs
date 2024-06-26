﻿using Lazada.Data;
using Lazada.Interface;
using Lazada.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Web.Helpers;


namespace Lazada.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LazadaDBContext _context;

        public OrderRepository(LazadaDBContext context)
        {
            _context = context;
        }

        public bool AddtoOrder(long userid, List<long> cartitemids, long voucherid)
        {
            User user = _context.Users.SingleOrDefault(s => s.Id == userid);
            if (user == null)
            {
                return false;
            }
            Address addressdefault = _context.Addresses.Where(s => s.Users.Id == userid
            && s.Address_Default).FirstOrDefault();
            if (addressdefault == null)
            {
                return false;
            }

            var voucher_discount = 0;
            double Pricediscount = 0;
            //Them truong hop ko co id voucher thi nhap ko va xu ly 
            //quan ly tgian han su dung voucher
            var cartItems = _context.CartItems.Include(s => s.Product)
                                                      .Include(s => s.Carts)
                                                      .ThenInclude(s => s.Shops)
                                                      .Where(s => cartitemids.Contains(s.Id) &&
                                                        s.Carts.Users.Id == userid && 
                                                        s.Status == Status_cart_item.active &&
                                                        s.Product.inventory >= s.quantity)
                                                      .ToList();
            if (cartItems == null)
            {
                return false;
            }
            if (voucherid != 0)
            {
                var Voucherapplied = _context.Vouchers.Include(s => s.User)
                                                       .Where(s => s.Id == voucherid &&
                                                       s.User.Id == userid &&
                                                       s.expire_date > DateTime.UtcNow)
                                                       .FirstOrDefault();
                if (Voucherapplied != null)
                {
                    voucher_discount = Voucherapplied.discount;
                }
            }
            var shopid = _context.CartItems.First().Carts.Shops.Id;
            Shop shop = _context.Shops.SingleOrDefault(s => s.Id == shopid);
            if(shop == null)
            {
                return false;
            }
            foreach (var cartItem in cartItems)
            {
                Pricediscount += (cartItem.Product.ProductPrice*(1 - (voucher_discount / 100)))*cartItem.quantity;
                cartItem.Status = Status_cart_item.order;
                cartItem.Product.inventory -= cartItem.quantity;
            }
            Order newOrder = new Order
            {
                User = user,
                Shop = shop,
                Address = addressdefault,
                TotalPrice = Pricediscount,
                time = DateTime.UtcNow,
                status = Status_Order.cho_thanh_toan,
                list_cartitem = cartItems,
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return true;
        }

        public List<Order_Get> GetOrderbyUserId(long userId)
        {
            List<Order_Get> response = new List<Order_Get>();
            User user = _context.Users.SingleOrDefault(s => s.Id == userId);
            if (user == null)
            {
                return response;
            }
            Address address = _context.Addresses.SingleOrDefault(s => s.Users.Id == userId);
            if(address == null)
            {
                return response;
            }
            var orders = _context.Orders.Include(s => s.list_cartitem).ThenInclude(s => s.Product).Where(s => s.User.Id == userId)
                .Select(s => new Order_Get
                {
                    orderid = s.Id,
                    userId_order = user.Id,
                    username_order = user.Name,
                    address = address.Address_Detail,
                    shopid_order = s.Shop.Id,
                    cartitem = s.list_cartitem.Select(s => $"ProductId:{s.Product.ProductId} - ProductName:{s.Product.ProductName}" +
                    $" - Quantity:{s.quantity} - Options:{s.option}").ToList(),
                    TotalPrice = s.TotalPrice
                }).ToList();
            return orders;
        }

        public bool CancleOrder(long orderId)
        {
            Order orders = _context.Orders.SingleOrDefault(s => s.Id == orderId);
            if (orders == null)
            {
                return false;
            }
            _context.Orders.Remove(orders);
            _context.SaveChanges();
            return true;
        }

        public List<Order_Get> GetOrderbyShopid(long shopid)
        {
            List<Order_Get> response = new List<Order_Get>();
            Shop shop = _context.Shops.SingleOrDefault(s => s.Id == shopid);
            if(shop == null)
            {
                return response;
            }
            var order = _context.Orders.Include(s => s.User).Include(s => s.Address)
                .Include(s => s.list_cartitem).ThenInclude(s => s.Product).Where( s => s.Shop.Id == shopid)
                .Select(s => new Order_Get
                {
                    orderid = s.Id,
                    userId_order = s.User.Id,
                    username_order = s.User.Name,
                    shopid_order = shopid,
                    address = s.Address.Address_Detail,
                    cartitem = s.list_cartitem.Select(s => $"ProductId:{s.Product.ProductId} - ProductName:{s.Product.ProductName}" +
                    $"- Quantity:{s.quantity} - Options:{s.option}").ToList(),
                    TotalPrice = s.TotalPrice,
                }).ToList();
            return order;
        }
    }
}
