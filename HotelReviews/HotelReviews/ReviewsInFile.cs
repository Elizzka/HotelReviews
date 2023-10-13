namespace HotelReviews
{
    public abstract class ReviewsInFile : ReviewsBase
    {
        public override event OpinionAddedDelegate OpinionAdded;

        private const string fileName = "reviews.txt";

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

                    if (OpinionAdded != null)
                    {
                        OpinionAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("invalid opinion value");
            }
        }

        public new abstract void AddOpinion(string opinion);

        public new abstract void AddOpinion(char opinion);

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            var opinionsFromFile = this.ReadOpinionsFromFile();

            foreach (var opinion in opinionsFromFile)
            {
                statistics.AddOpinion(opinion);
            }

            return statistics;
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
    }
}
