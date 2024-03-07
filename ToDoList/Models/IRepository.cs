﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DatabaseTest.Model
{
    /// <summary>
    /// <see cref="IRepository{T}"/> represents the Repository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}