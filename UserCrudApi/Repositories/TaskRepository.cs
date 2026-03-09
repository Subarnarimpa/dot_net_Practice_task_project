using UserCrudApi.Data;
using UserCrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace UserCrudApi.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Todo>> GetAllTasks()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo?> GetTaskById(int id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task<Todo> CreateTask(Todo task)
    {
        _context.Todos.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Todo?> UpdateTask(int id, Todo task)
    {
        var existingTask = await _context.Todos.FindAsync(id);
        if (existingTask == null)
        {
            return null;
        }

        existingTask.Title = task.Title;
        existingTask.Description = task.Description;
        existingTask.Status = task.Status;
        existingTask.UserId = task.UserId;

        await _context.SaveChangesAsync();
        return existingTask;
    }

    public async Task<bool> DeleteTask(int id)
    {
        var task = await _context.Todos.FindAsync(id);
        if (task == null)
        {
            return false;
        }

        _context.Todos.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
}