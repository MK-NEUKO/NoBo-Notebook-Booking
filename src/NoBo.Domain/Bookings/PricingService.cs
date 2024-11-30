using NoBo.Domain.Notebooks;
using NoBo.Domain.Shared;

namespace NoBo.Domain.Bookings;

public class PricingService
{
    public PricingDetails CalculatePrice(Notebook notebook, DateRange period)
    {
        var currency = notebook.Price.Currency;

        var priceOfPeriod = new Money(
            notebook.Price.Amount * period.LengthInDays,
            currency);

        decimal percentageUpCharge = 0;
        foreach(var accessory in notebook.Accessories)
        {
            percentageUpCharge += accessory switch
            {
                Accessories.Mouse or Accessories.Headset => 0.03m,
                Accessories.Bag => 0.05m,
                _ => 0
            };
        }

        var accessoriesUpCharge = Money.Zero(currency);
        if (percentageUpCharge > 0)
        {
            accessoriesUpCharge = new Money(
                priceOfPeriod.Amount * percentageUpCharge,
                currency);
        }

        var totalPrice = Money.Zero();
        totalPrice += accessoriesUpCharge;

        return new PricingDetails(priceOfPeriod, accessoriesUpCharge, totalPrice);
    }
}