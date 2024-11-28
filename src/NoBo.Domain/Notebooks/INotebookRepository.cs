namespace NoBo.Domain.Notebooks;

public interface INotebookRepository
{
    Task<Notebook> GetByIdAsync(Guid id, CancellationToken cancellation = default);
}