using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
            TaskModels = new ObservableCollection<TaskModel>();
        }

        [ObservableProperty]
        string taskName;

        [ObservableProperty]
        ObservableCollection<TaskModel> taskModels;

        [RelayCommand]
        public void AddTask()
        {
            if (string.IsNullOrEmpty(TaskName))
                return;

            if (TaskModels.Any(task => task.Name == TaskName))
                return;

            TaskModels.Add(new TaskModel() { Id = new Random().Next(), Name = TaskName, Description = $"{TaskName} description" });

            TaskName = string.Empty;
        }

        [RelayCommand]
        public void RemoveTask(string taskName)
        {
            TaskModel task = TaskModels.SingleOrDefault(task => task.Name == taskName);

            if (task != null)
            {
                TaskModels.Remove(task);
            }
        }

        [RelayCommand]
        public async Task ShowDetails(string taskName)
        {
            TaskModel task = TaskModels.SingleOrDefault(task => task.Name == taskName);

            if (task != null)
            {
                await Shell.Current.GoToAsync(nameof(DetailPage), new Dictionary<string, object>() { { "TaskData", task } });
            }
        }
    }
}
