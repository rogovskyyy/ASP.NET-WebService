using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UserApi.Database.Entities;

namespace UserApi.Service
{
    //TODO: Make generic repository when DatabaseContext from EF Core will be implemented
    public interface IUserRepository
    {
        List<User> FindBy(Predicate<User> predicate);
    }
}