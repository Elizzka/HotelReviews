namespace HotelReviews
{
    public class ReviewsInFile : ReviewsBase
    {
        public override event OpinionAddedDelegate OpinionAdded;

        private const string fileName = "opinions.txt";

        public ReviewsInFile(string hotelName)
            : base(hotelName)
        {
        }

        public override void AddOpinion(float opinion)
        {
            if (opinion >= 0 && opinion <= 5)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(opinion);
                }

                if (OpinionAdded != null)
                {
                    OpinionAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("invalid opinion value");
            }
        }

        public override Statistics GetStatistics()
        {
            var opinionsFromFile = this.ReadOpinionsFromFile();
            var result = this.CalculateStatistics(opinionsFromFile);
            return result;
        }

        private List<float> ReadOpinionsFromFile()
        {
            var opinions = new List<float>();
            if (File.Exists($"{fileName}"))
            {
                using (var reader = File.OpenText($"{fileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        opinions.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return opinions;
        }

        private Statistics CalculateStatistics(List<float> opinions)
        {
            var statistics = new Statistics();

            foreach (var opinion in opinions)
            {
                statistics.AddOpinion(opinion);
            }
            return statistics;
        }
    }
}

