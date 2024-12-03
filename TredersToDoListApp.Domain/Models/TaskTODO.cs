namespace TredersToDoListApp.Domain.Models;
public class TaskTODO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }

    //public void UpdateStatus(string newStatus)
    //{
    //    Status = newStatus;
    //}

    //public string Validate()
    //{
    //    if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description))
    //        return "Name and Description cannot be empty";
    //    return "Valid";
    //}
}
