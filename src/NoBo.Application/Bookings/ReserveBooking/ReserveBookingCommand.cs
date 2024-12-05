using NoBo.Application.Abstractions.Messaging;

namespace NoBo.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand(
    Guid NotebookId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<Guid>;