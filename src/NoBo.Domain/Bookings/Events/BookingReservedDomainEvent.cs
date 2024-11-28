using NoBo.Domain.Abstractions;

namespace NoBo.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;