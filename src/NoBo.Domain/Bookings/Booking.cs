using NoBo.Domain.Abstractions;
using NoBo.Domain.Bookings.Events;
using NoBo.Domain.Notebooks;
using NoBo.Domain.Shared;

namespace NoBo.Domain.Bookings;

public class Booking : Entity
{
    private Booking(
        Guid id,
        Guid notebookId,
        Guid userId,
        DateRange duration,
        Money priceForPeriod,
        Money accessoriesUpCharge,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc) 
        : base(id)
    {
        NotebookId = notebookId;
        UserId = userId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        AccessoriesUpCharge = accessoriesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;
    }

    public Guid NotebookId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money AccessoriesUpCharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }

    public static Booking Reserve(
        Notebook notebook,
        Guid userId,
        DateRange duration,
        DateTime utcNow,
        PricingService pricingService)
    {
        var pricingDetails = pricingService.CalculatePrice(notebook, duration);

        var booking = new Booking(
            Guid.NewGuid(),
            notebook.Id,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.AccessoriesUpCharge,
            pricingDetails.TotalPrice,
            BookingStatus.Reserved,
            utcNow);

        booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));

        notebook.LastBookedOnUtc = utcNow;

        return booking;
    }
}