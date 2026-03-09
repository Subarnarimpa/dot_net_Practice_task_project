using UserCrudApi.DTOs;
using UserCrudApi.Models;
using UserCrudApi.Repositories;

namespace UserCrudApi.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<Todo>> GetAllTasks()
    {
        return await _taskRepository.GetAllTasks();
    }

    public async Task<Todo?> GetTaskById(int id)
    {
        return await _taskRepository.GetTaskById(id);
    }

    public async Task<Todo> CreateTask(CreateTaskDto dto)
    {
        var task = new Todo
        {
            Title = dto.Title,
            Description = dto.Description,
            Status = dto.Status,
            UserId = dto.UserId,
            CreatedAt = DateTime.UtcNow
        };

        return await _taskRepository.CreateTask(task);
    }

    public async Task<Todo?> UpdateTask(int id, UpdateTaskDto dto)
    {
        var task = new Todo
        {
            Title = dto.Title,
            Description = dto.Description,
            Status = dto.Status
        };

        return await _taskRepository.UpdateTask(id, task);
    }

    public async Task<bool> DeleteTask(int id)
    {
        return await _taskRepository.DeleteTask(id);
    }
}