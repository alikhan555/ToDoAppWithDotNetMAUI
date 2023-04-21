using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.DAL
{
    public class TaskToDoRepository : DBContext
    {
        public async Task<TaskToDo> SingleOrDefault(Guid guid)
        {
            return await database.Table<TaskToDo>().Where(task => task.guid == guid).FirstOrDefaultAsync();
        }

        public async Task<List<TaskToDo>> GetTaskToDos()
        {
            return await database.Table<TaskToDo>().ToListAsync();
        }

        public async Task<int> SaveTaskToDo(TaskToDo task)
        {
            return await database.InsertAsync(task);
        }

        public async Task<int> RemoveTaskToDo(TaskToDo task)
        {
            return await database.DeleteAsync(task);
        }

        public async Task<int> RemoveAllTaskToDo()
        {
            return await database.DeleteAllAsync<TaskToDo>();
        }
    }
}
