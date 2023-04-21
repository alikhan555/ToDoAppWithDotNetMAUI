using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.ViewModel
{
    [QueryProperty("TaskGuid", "TaskGuid")]
    [QueryProperty("Task", "TaskModel")]
    public partial class DetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        Guid taskGuid;

        [ObservableProperty]
        TaskModel task;

        [RelayCommand]
        public async Task GoBack()
        {
            if (await Shell.Current.DisplayAlert("Warning", "Are you sure you want to go back?", "Yes", "No"))
            {
                await Shell.Current.GoToAsync("../");
            }
        }
    }
}
