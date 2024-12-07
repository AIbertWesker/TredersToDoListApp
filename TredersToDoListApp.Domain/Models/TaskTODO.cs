namespace TredersToDoListApp.Domain.Models;

public class TaskTODO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }

    public string Validate()
    {
        if (string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.Status))
            return "false";
        return "true";
    }
}
