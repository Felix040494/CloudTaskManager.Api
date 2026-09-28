using CloudTaskManager.Api.Models;

namespace CloudTaskManager.Api.Services;

public interface ITaskRepository
{
    IReadOnlyCollection<TaskItem> GetAll();
    TaskItem? GetById(int id);
    TaskItem Create(CreateTaskRequest request);
    TaskItem? Update(int id, UpdateTaskRequest request);
    bool Delete(int id);
}
