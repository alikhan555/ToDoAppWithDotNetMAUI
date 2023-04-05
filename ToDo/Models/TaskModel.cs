﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public partial class TaskModel : ObservableObject
    {
        [ObservableProperty]

        public int id;
        [ObservableProperty]

        public string name;
        [ObservableProperty]
        public string description;
    }
}
