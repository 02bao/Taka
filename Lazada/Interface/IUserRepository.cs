﻿using Lazada.Models;

namespace Lazada.Interface
{
    public interface IUserRepository
    {
        ICollection<User> GetUser();
        User GetById(int id);
        bool Register(User user);
        bool Login(User_login user);  
        bool Update(User_update user);
        bool Delete(User user);
    }
}
