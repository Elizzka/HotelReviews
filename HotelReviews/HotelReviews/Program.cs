using HotelReviews;
;

Console.WriteLine("Witamy w programie, w którym możesz wystawić opinię dla hotelu: Perła.");
Console.WriteLine("--------------------------------------------");
Console.WriteLine();
Console.WriteLine("Podaj ocenę od 1 do 5 lub podaj literę z poniższej listy: ");
Console.WriteLine("'E' - excellent");
Console.WriteLine("'G' - good");
Console.WriteLine("'A' - average");
Console.WriteLine("'P' - poor");
Console.WriteLine("'N' - negative");
Console.WriteLine("Po dodaniu opinii naciśnij '-' i wyświetl ocenę najwyższą, najniższą i średnią wszystkich ocen. ");

var reviews = new ReviewsInMemory("Hotel Perła");
reviews.OpinionAdded += ReviewsOpinionAdded;

void ReviewsOpinionAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano nową opinię");
}


while (true)
{
    Console.WriteLine("Dodaj kolejną opinię dla naszego hotelu");
    var input = Console.ReadLine();
    if (input == "-")
    {
        break;
    }

    try
    {
        reviews.AddOpinion(input);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception catched: {e.Message}");
    }
}

var statistics = reviews.GetStatistics();
Console.WriteLine($"Average: {statistics.Average:N2}");
Console.WriteLine($"Average: {statistics.AverageLetter}");
Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");