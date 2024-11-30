using NoBo.Domain.Abstractions;

namespace NoBo.Domain.Bookings.Events;

public record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;