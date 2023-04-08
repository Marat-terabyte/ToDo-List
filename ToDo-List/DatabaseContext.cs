using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace ToDo_List
{
    public class DatabaseContext
    {
        private SQLiteConnection _connection;

        private static readonly string _nameOfFile = "Database.db";
        private readonly string _source = $"Data Source={_nameOfFile};";

        public DatabaseContext()
        {
            CreateDataBase();
        }

        public void CreateDataBase()
        {
            if (!IsDatabaseExists())
                CreateFile();

            _connection = new SQLiteConnection(_source);
            _connection.Open();

            CreateTable();
        }

        private bool IsDatabaseExists() => File.Exists(_nameOfFile);

        private void CreateFile() => File.Create(_nameOfFile);

        private void CreateTable()
        {
            string query = "CREATE TABLE IF NOT EXISTS tasks(\"Id\" INTEGER,\"Title\" TEXT NOT NULL," +
                "\"Description\" TEXT," +
                "\"StartTime\" TEXT," +
                "\"EndTime\" TEXT," +
                "\"IsDone\" TEXT," +
                "PRIMARY KEY(\"Id\")" +
                ");";

            SQLiteCommand command = new SQLiteCommand(_connection);
            command.CommandText = query;
            command.ExecuteNonQuery();
        }

        public ObservableCollection<Models.Task> GetTasks()
        {
            ObservableCollection<Models.Task> tasks = new ObservableCollection<Models.Task>();

            string query = "SELECT * FROM tasks;";

            SQLiteCommand command = new SQLiteCommand(_connection);
            command.CommandText = query;
            
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                string? description = reader.GetValue(2).ToString();
                string? startTime = reader.GetValue(3).ToString();
                string? endTime = reader.GetValue(4).ToString();
                bool isDone = Convert.ToBoolean(reader.GetString(5));

                tasks.Add(new Models.Task(this)
                {
                    Id = id,
                    Title = title,
                    Description = description,
                    StartTime = startTime,
                    EndTime = endTime,
                    IsDone = isDone
                });
            }

            return tasks;
        }

        public async void AddTask(Models.Task task)
        {
            await Task.Run(() =>
            {
                string query = "INSERT INTO tasks(Title, Description, StartTime, EndTime, IsDone)" +
                    "VALUES(" +
                    $"'{task.Title}'," +
                    $"'{task.Description}'," +
                    $"'{task.StartTime}'," +
                    $"'{task.EndTime}'," +
                    $"'{task.IsDone}'" +
                    ");";

                SQLiteCommand command = new SQLiteCommand(_connection);
                command.CommandText = query;
                command.ExecuteNonQuery();
            });
        }

        public async void ExecuteCommand(string query)
        {
            await Task.Run(() =>
            {
                SQLiteCommand command = new SQLiteCommand(_connection);
                command.CommandText = query;
                command.ExecuteNonQuery();
            });
        }
    }
}
