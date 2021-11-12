using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebService.Models;

namespace WebService.Repositories
{
    public class UserRepo : IRepository<User>
    {
        private IMemoryCache _cache;
        private List<int> _key;

        public UserRepo(IMemoryCache cashe, List<int> key)
        {
            _cache = cashe;
            _key = key;
        }

        public string Delete(int id)
        {
            if (_cache.Get<User>(id) is not null)
            {
                _cache.Remove(id);
                _key.Remove(id);
                return "OK";
            }
            else
            {
                return "Error!";
            }
        }

        public string Post(User user)
        {
            if (user is not null && _cache.Get<User>(user.ID) is null)
            {
                _cache.Set(user.ID, user);
                _key.Add(user.ID);
                return "OK";
            }
            else
            {
                return "Error!";
            }
        }

        public string Put(User user)
        {
            if (user is not null)
            {
                _cache.Set(user.ID, user);
                _key.Add(user.ID);
                return "OK";
            }
            else
            {
                return "Error!";
            }
        }

        public (IEnumerable<User>, string) Get()
        {
            List<User> users = new();
            if (_cache is not null)
            {
                foreach (int k in _key)
                {
                    users.Add(_cache.Get<User>(k));
                }
                return (users, "OK");
            }
            else
            {
                return (users, "Error!");
            }
        }

        public (User, string) GetOne(int id)
        {
            User user = new();
            if(_cache.Get<User>(id) is not null)
            {
                user = _cache.Get<User>(id);
                return (user, "OK");
            }
            else
            {
                return (user, "Error!");
            }
        }
    }
}
