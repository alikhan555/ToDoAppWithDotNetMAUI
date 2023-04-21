using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.DAL
{
    public class DBContext
    {
        protected SQLiteAsyncConnection database;

        public DBContext()
        {
            OpenConnection();
            CreateDatabase();
        }

        public void OpenConnection()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(DBConfig.DatabasePath, DBConfig.Flags);
        }

        private void CreateDatabase()
        {
            var result = database.CreateTableAsync<TaskToDo>().GetAwaiter().GetResult();
        }
    }
}
