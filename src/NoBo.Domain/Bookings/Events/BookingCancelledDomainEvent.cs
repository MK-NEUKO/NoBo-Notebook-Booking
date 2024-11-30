using NoBo.Domain.Abstractions;

namespace NoBo.Domain.Bookings.Events;

public record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;