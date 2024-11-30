using NoBo.Domain.Abstractions;

namespace NoBo.Domain.Bookings.Events;

public record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;