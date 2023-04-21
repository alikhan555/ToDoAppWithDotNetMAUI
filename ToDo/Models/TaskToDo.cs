using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class TaskToDo

    {
        [PrimaryKey, AutoIncrement  ]
        public int Id { get; set; }

        public Guid guid { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
    }
}
