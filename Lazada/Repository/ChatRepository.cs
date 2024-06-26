﻿using Lazada.Data;
using Lazada.Interface;
using Lazada.Models;
using Microsoft.EntityFrameworkCore;

namespace Lazada.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly LazadaDBContext _context;

        public ChatRepository(LazadaDBContext context)
        {
            _context = context;
        }

        public Conversation_US GetConversation_ById(long userid, long shopid)
        {
            Conversation_US response = new Conversation_US();
            List<Message_US> respone_message = new List<Message_US>();
            User user = _context.Users.SingleOrDefault(s => s.Id == userid);
            if(user == null)
            {
                return response;
            }
            Shop shop = _context.Shops.Include(s => s.User).SingleOrDefault(s => s.Id == shopid);
            if(shop == null || shop.User.Id == userid)
            {
                return response;
            }
            response.username = user.Name;
            response.shopname = shop.Name;
            Conversation conversation  = _context.Conversations.Include( s => s.Shop).Include(s => s.User)
                .Where( s => s.Shop == shop && s.User == user ).Include(s => s.Message).FirstOrDefault();
            if(conversation == null)
            {
                return response;
            }
            else
            {
                if(conversation.Message.Any())
                {
                    List<Message> messages = conversation.Message;
                    foreach(Message message in messages)
                    {
                        Message_US item = new Message_US
                        {
                            message = message.message,
                            type = message.type,
                            time = message.time.AddHours(7),
                        };
                        respone_message.Add(item);
                    }
                    response.messages = respone_message.OrderByDescending(s => s.time).ToList();
                }
            }
            return response;
        }

        public bool NewMessage(long userid, long shopid, string mess)
        {
            User user = _context.Users.SingleOrDefault( s => s.Id  == userid );
            if(user == null)
            {
                return false;
            }
            Shop shop = _context.Shops.Include( s=> s.User).SingleOrDefault(s => s.Id == shopid);
            if(shop == null || shop.User.Id == userid)
            {
                return false;
            }
            Conversation conversation = _context.Conversations.Include(s => s.User).Include(s => s.Shop)
                .Where(s => s.Shop == shop && s.User == user).Include( s=> s.Message).FirstOrDefault();
            if(conversation == null)
            {
                conversation = new Conversation
                {
                    User = user,
                    Shop = shop,
                    is_seen = false,
                    lasttime = DateTime.UtcNow,
                    Message = new List<Message>()
                };
            _context.Conversations.Add(conversation);
            }
            Message NewMessage = new Message
            {
                type = true,
                message = mess,
                time = DateTime.UtcNow,
                Conversation = conversation,
            };
            conversation.Message.Add(NewMessage);
            _context.SaveChanges();
            return true;
        }
    }
}
