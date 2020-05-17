using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UserApi.Database;
using UserApi.Database.Entities;

namespace UserApi.Service
{
    public class UserRepository : IUserRepository
    {
        public List<User> FindBy(Predicate<User> predicate)
        {
            return new List<User> {new User {Id = 1, Email = "a@a.pl", Password = "test"}}.FindAll(predicate);
        }
    }
}