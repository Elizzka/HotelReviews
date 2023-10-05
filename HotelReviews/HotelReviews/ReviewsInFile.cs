﻿namespace HotelReviews
{
    public class ReviewsInFile : ReviewsBase
    {
        public delegate void OpinionAddedDelegate(object sender, EventArgs args);

        public event OpinionAddedDelegate OpinionAdded;

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

        public override void AddOpinion(string opinion)
        {
            if (float.TryParse(opinion, out float result))
            {
                this.AddOpinion(result);
            }
            else
            {
                throw new Exception("String is not float");
            }
        }

        public override void AddOpinion(char opinion)
        {
            switch (opinion)
            {
                case 'E':   
                    this.AddOpinion(5);
                    break;
                case 'G':    
                    this.AddOpinion(4);
                    break;
                case 'A':     
                    this.AddOpinion(3);
                    break;
                case 'P':     
                    this.AddOpinion(2);
                    break;
                case 'N':     
                    this.AddOpinion(1);
                    break;
                default:
                    throw new Exception("Wrong letter");
            }
        }

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