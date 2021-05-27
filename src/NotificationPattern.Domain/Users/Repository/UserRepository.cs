using NotificationPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationPattern.Domain.Users.Repository
{
    public class UserRepository
    {
        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            var currentUser = GetById(user.Id);

            if (currentUser != null) currentUser = user;
        }
    }
}
