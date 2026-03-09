using UserCrudApi.Models;

namespace UserCrudApi.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<Todo>> GetAllTasks();
    Task<Todo?> GetTaskById(int id);
    Task<Todo> CreateTask(Todo task);
    Task<Todo?> UpdateTask(int id, Todo task);
    Task<bool> DeleteTask(int id);
}