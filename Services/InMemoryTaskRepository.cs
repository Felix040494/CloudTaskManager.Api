using System.Collections.Concurrent;
using CloudTaskManager.Api.Models;

namespace CloudTaskManager.Api.Services;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly ConcurrentDictionary<int, TaskItem> _tasks = new();
    private int _nextId = 0;

    public InMemoryTaskRepository()
    {
        Create(new CreateTaskRequest
        {
            Title = "Learn Azure App Service",
            Description = "Deploy the .NET 8 API to Azure.",
            DueDate = DateTime.UtcNow.AddDays(7)
        });

        Create(new CreateTaskRequest
        {
            Title = "Configure Azure SQL",
            Description = "Connect the API to Azure SQL in the next phase.",
            DueDate = DateTime.UtcNow.AddDays(14)
        });
    }

    public IReadOnlyCollection<TaskItem> GetAll()
        => _tasks.Values.OrderBy(x => x.Id).ToArray();

    public TaskItem? GetById(int id)
        => _tasks.TryGetValue(id, out var task) ? task : null;

    public TaskItem Create(CreateTaskRequest request)
    {
        var id = Interlocked.Increment(ref _nextId);

        var task = new TaskItem
        {
            Id = id,
            Title = request.Title.Trim(),
            Description = request.Description?.Trim(),
            Status = "Pending",
            CreatedAt = DateTime.UtcNow,
            DueDate = request.DueDate
        };

        _tasks[id] = task;
        return task;
    }

    public TaskItem? Update(int id, UpdateTaskRequest request)
    {
        if (!_tasks.TryGetValue(id, out var existing))
            return null;

        existing.Title = request.Title.Trim();
        existing.Description = request.Description?.Trim();
        existing.Status = request.Status;
        existing.DueDate = request.DueDate;

        _tasks[id] = existing;
        return existing;
    }

    public bool Delete(int id)
        => _tasks.TryRemove(id, out _);
}
