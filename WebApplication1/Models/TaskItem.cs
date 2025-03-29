namespace WebApplication1.Models;
public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = "Pendiente"; // "Pendiente" o "Completada"
}