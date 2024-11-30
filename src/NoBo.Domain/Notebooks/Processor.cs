namespace NoBo.Domain.Notebooks;

public record Processor(
    string Name,
    string Cores,
    string Threads,
    string ClockSpeed
    );