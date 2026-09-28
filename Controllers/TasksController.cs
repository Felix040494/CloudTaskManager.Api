using CloudTaskManager.Api.Models;
using CloudTaskManager.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudTaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;

    public TasksController(ITaskRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyCollection<TaskItem>> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TaskItem> GetById(int id)
    {
        var task = _repository.GetById(id);

        return task is null
            ? NotFound(new { message = $"Task with id {id} was not found." })
            : Ok(task);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TaskItem> Create(CreateTaskRequest request)
    {
        var task = _repository.Create(request);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TaskItem> Update(int id, UpdateTaskRequest request)
    {
        var task = _repository.Update(id, request);

        return task is null
            ? NotFound(new { message = $"Task with id {id} was not found." })
            : Ok(task);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        return _repository.Delete(id)
            ? NoContent()
            : NotFound(new { message = $"Task with id {id} was not found." });
    }
}
