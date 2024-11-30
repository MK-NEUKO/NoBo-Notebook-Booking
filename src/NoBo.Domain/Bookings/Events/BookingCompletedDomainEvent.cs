using NoBo.Domain.Abstractions;

namespace NoBo.Domain.Bookings.Events;

public record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;