using NoBo.Domain.Abstractions;

namespace NoBo.Domain.Notebooks;

public static class NotebookErrors
{
    public static Error NotFound = new(
        "Notebook.NotFound",
        "The notebook with the specified identifier was not found.");
}