using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Server.DataBase
{
    public abstract class Repository<T> : IDisposable
                where T : class
    {
        public abstract void Dispose();
        public abstract IEnumerable<T> GetList();
        public abstract T GetItem(int id);

        public abstract bool Create(T item);
        public abstract bool Update(T item);
        public abstract bool Delete(int id);
        public abstract void Save();
    }
}