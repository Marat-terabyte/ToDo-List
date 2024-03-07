﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DatabaseTest.Model
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? DateLimit {  get; set; }
        public bool IsDone {  get; set; }

        public ToDoTask(string name, string? description, DateTime created, DateTime? dateLimit)
        {
            Name = name;
            Description = description;
            Created = created;
            DateLimit = dateLimit;
            IsDone = false;
        }

        public ToDoTask(string name, DateTime created)
        {
            Name = name;
            Created = created;
        }
    }
}