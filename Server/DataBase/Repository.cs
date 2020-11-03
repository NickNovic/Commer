using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.Account;

namespace Server.DataBase
{
    public interface IAccountRepository<T> : IDisposable
                where T : class
    {
        public void Dispose();
        //public IEnumerable<T> GetList();
        //public T GetItem(int id);
        public bool Create(T item);
        //public bool Update(T item);
        public bool Delete(int id);
        public void Save();
        public bool Authorize(AuthorizationModel model);
    }
}