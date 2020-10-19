using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Server.DataBase
{
    public interface IRepository<T> : IDisposable
                where T : class
    { 
        IEnumerable<T> GetList();
        T GetItem(int id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(int id);
        void Save();
    }
}