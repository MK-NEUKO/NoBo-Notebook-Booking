using NoBo.Domain.Notebooks;
using NoBo.Domain.Shared;

namespace NoBo.Domain.Bookings;

public record PricingDetails(
    Money PriceForPeriod,
    Money AccessoriesUpCharge,
    Money TotalPrice);