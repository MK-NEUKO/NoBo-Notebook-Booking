using NoBo.Application.Abstractions.Messaging;

namespace NoBo.Application.Notebooks.SearchNotebooks;

public record SearchNotebooksQuery(
    DateOnly StartDate,
    DateOnly EndDate) : IQuery<IReadOnlyList<NotebookResponse>>;