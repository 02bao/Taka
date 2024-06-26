﻿namespace Lazada.Models
{
    public class User
    {
        public long Id { get; set; } = DateTime.UtcNow.Ticks/100;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public List<Shop>? shops { get; set; }
        public List<Voucher>? vouchers { get; set; }
        public List<Notification> notifications { get; set; }
    }

    public class User_register
    {
        public long Id { get; set; } = DateTime.UtcNow.Ticks / 100;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class User_login
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
    

    public class User_update
    {
        public long Id { get; set; } = DateTime.UtcNow.Ticks/100;
        public string Password { get; set; }
        public string Phone { get; set; }
    }

    public class User_Forget
    {
        public long Id { get; set; } = DateTime.UtcNow.Ticks / 100;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
