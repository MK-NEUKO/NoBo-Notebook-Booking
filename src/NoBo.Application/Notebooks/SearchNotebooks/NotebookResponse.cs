namespace NoBo.Application.Notebooks.SearchNotebooks;

public sealed class NotebookResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public string Currency { get; init; }
    public string ArticleNumber { get; set; }
}