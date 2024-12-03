namespace TredersToDoListApp.Domain.Models;
public class TaskeManager
{
    private List<TaskTODO> tasks = new();

    //public string AddTask(TaskTODO task)
    //{
    //    //var validationMessage = task.Validate();
    //    //if (validationMessage != "Valid")
    //    //    return validationMessage;

    //    //tasks.Add(task);
    //    //return "Task added successfully";
    //}

    public List<TaskTODO> GetTasks()
    {
        return tasks;
    }

    public TaskTODO GetTaskById(int taskId)
    {
        return tasks.FirstOrDefault(t => t.Id == taskId);
    }

    public string DeleteTask(int taskId)
    {
        var task = GetTaskById(taskId);
        if (task == null)
            return "Task not found";

        tasks.Remove(task);
        return "Task deleted successfully";
    }

    //public string ChangeStatus(int taskId, string newStatus)
    //{
    //    var task = GetTaskById(taskId);
    //    if (task == null)
    //        return "Task not found";

    //    task.UpdateStatus(newStatus);
    //    return "Task status updated successfully";
    //}
}

