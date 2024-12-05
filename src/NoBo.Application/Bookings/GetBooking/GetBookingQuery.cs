using NoBo.Application.Abstractions.Messaging;

namespace NoBo.Application.Bookings.GetBooking;

public record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;