using HotelReviews;

Console.WriteLine("Welcome to the program where you can leave a review for the hotel: Perła.");
Console.WriteLine("--------------------------------------------");
Console.WriteLine();
Console.WriteLine("Provide a rating from 1 to 5 or enter a letter from the list below: ");
Console.WriteLine("'E' - excellent");
Console.WriteLine("'G' - good");
Console.WriteLine("'A' - average");
Console.WriteLine("'P' - poor");
Console.WriteLine("'N' - negative");
Console.WriteLine("After adding a review, press '-' and display the highest, lowest and average rating of all ratings. ");

var reviews = new ReviewsInFile("Hotel Perła");
reviews.OpinionAdded += ReviewsOpinionAdded;

void ReviewsOpinionAdded(object sender, EventArgs args)
{
    Console.WriteLine("A new opinion has been added");
}

while (true)
{
    Console.WriteLine("Add another review for our hotel");
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
Console.WriteLine("Statistics for the hotel:");
Console.WriteLine($"Average: {statistics.Average:N2}");
Console.WriteLine($"AverageLetter: {statistics.AverageLetter}");
Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");