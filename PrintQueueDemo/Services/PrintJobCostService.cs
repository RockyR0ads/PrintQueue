using PrintQueueDemo.Models;

namespace PrintQueueDemo.Services;

public class PrintJobCostService
{
    private readonly Dictionary<string, decimal> FilamentCostPerGram = new()
    {
        { "PLA", 0.05m },
        { "PETG", 0.07m },
        { "ABS", 0.08m }
    };
    private readonly Dictionary<string, decimal> MachineWattage = new()
    {
        { "P1P", 90 },
        { "A1Mini", 57 },
        { "A1", 100 }
    };
    private const decimal MachineHourlyRate = 3.50m; // wear
    private const decimal MarkupPercentage = 0.20m;  // 20% markup

    public decimal CalculateCost(PrintJob job, PricingConfig config)
    {
        // 1. Base material cost
        var filamentCost = FilamentCostPerGram.TryGetValue(job.FilamentType, out var cost) ? cost : 0.05m; // default

        var gramsUsed = job.EstimatedMinutes / 5m;
        var materialCost = gramsUsed * filamentCost;

        // 2. Machine time cost (wear + maintenance)
        var hours = job.EstimatedMinutes / 60m;
        var machineCost = hours * MachineHourlyRate;

        // 3. Electricity cost (correct formula)
        decimal wattage = MachineWattage.TryGetValue(job.Printer, out var w) ? w : 80; // default wattage if unknown

        decimal kwhUsed = (wattage / 1000m) * hours;
        decimal electricityCost = kwhUsed * config.ElectricityCostPerKwh;

        // 4. Subtotal
        var subtotal = materialCost + machineCost + electricityCost;

        // 5. Apply markup
        var finalCost = subtotal * (1 + MarkupPercentage);

        return Math.Round(finalCost, 2);
    }

}
