namespace PrintQueueDemo.Models;

public class PrintJob
{
    public int Id { get; set; }
    public string ModelName { get; set; } = "";
    public string Printer { get; set; } = "";
    public string FilamentType { get; set; } = "";
    public int EstimatedMinutes { get; set; }
    public string Status { get; set; } = "Queued"; // Queued, Printing, Done
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
