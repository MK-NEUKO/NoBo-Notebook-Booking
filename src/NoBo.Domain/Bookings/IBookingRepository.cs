using NoBo.Domain.Notebooks;

namespace NoBo.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(
        Notebook notebook,
        DateRange duration,
        CancellationToken cancellationToken = default);

    void Add(Booking booking);
}