using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DAL;
using ToDo.Models;

namespace ToDo.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string taskName;

        [ObservableProperty]
        ObservableCollection<TaskModel> taskModels;

        private readonly TaskToDoRepository _taskToDoRepository;
        private readonly Task loadingTask;

        public MainPageViewModel(TaskToDoRepository taskToDoRepository)
        {
            _taskToDoRepository = taskToDoRepository;
            loadingTask = Load();
        }

        [RelayCommand]
        public async Task AddTask()
        {
            if (string.IsNullOrEmpty(TaskName))
                return;

            TaskToDo taskToDo = new TaskToDo()
            {
                guid = Guid.NewGuid(),
                TaskName = TaskName,
                TaskDescription = $"{TaskName} description"
            };

            int status = await _taskToDoRepository.SaveTaskToDo(taskToDo);

            if (status > 0)
                await Load();

            TaskName = string.Empty;
        }

        [RelayCommand]
        public async Task RemoveTask(Guid guid)
        {
            TaskToDo task = await _taskToDoRepository.SingleOrDefault(guid);

            if (task is null)
            {
                await Shell.Current.DisplayAlert("Warning", "This task is not available.", "Okay");
                return;
            }
            else
            {
                await _taskToDoRepository.RemoveTaskToDo(task);
                await Load();
            }
        }

        [RelayCommand]
        public async Task ShowDetails(Guid guid)
        {
            TaskToDo task = await _taskToDoRepository.SingleOrDefault(guid);

            TaskModel taskModel = new TaskModel() { Id = task.Id, Guid = task.guid, Name = task.TaskName, Description = task.TaskDescription };

            if (task != null)
            {
                await Shell.Current.GoToAsync($"{nameof(DetailPage)}", new Dictionary<string, object>() { { "TaskGuid", guid }, { "TaskModel", taskModel } });
            }
        }

        public async Task Load()
        {
            List<TaskToDo> tasksTodos = await _taskToDoRepository.GetTaskToDos();

            TaskModels = null;

            if (TaskModels is null) 
                TaskModels = new ObservableCollection<TaskModel>();
            else 
                TaskModels.Clear();

            foreach (TaskToDo taskToDo in tasksTodos)
            {
                TaskModels.Add(new TaskModel() { Id = taskToDo.Id, Guid = taskToDo.guid, Description= taskToDo.TaskDescription, Name = taskToDo.TaskName });
            }
        }
    }
}
