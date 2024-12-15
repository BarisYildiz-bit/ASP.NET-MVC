public decimal CalculateQuote(Insuree insuree)
{
    decimal quote = 50m; // Base quote of $50/month

    // Age-based calculation
    int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
    if (age <= 18)
    {
        quote += 100;
    }
    else if (age >= 19 && age <= 25)
    {
        quote += 50;
    }
    else
    {
        quote += 25;
    }

    // Car year-based calculation
    if (insuree.CarYear < 2000)
    {
        quote += 25;
    }
    else if (insuree.CarYear > 2015)
    {
        quote += 25;
    }

    // Car make and model calculation
    if (insuree.CarMake == "Porsche")
    {
        quote += 25;
        if (insuree.CarModel == "911 Carrera")
        {
            quote += 25; // Additional for specific Porsche model
        }
    }

    // Speeding tickets
    quote += insuree.SpeedingTickets * 10;

    // DUI check
    if (insuree.HasDUI)
    {
        quote *= 1.25m; // Add 25% if user has had a DUI
    }

    // Full coverage check
    if (insuree.CoverageType == "Full")
    {
        quote *= 1.5m; // Add 50% for full coverage
    }

    return quote;
}
