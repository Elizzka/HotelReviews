using System.Diagnostics;

namespace HotelReviews
{
    public class ReviewsInMemory : ReviewsBase
    {
        public delegate void OpinionAddedDelegate(object sender, EventArgs args);

        public event OpinionAddedDelegate OpinionAdded;

        private List<float> opinions = new List<float>();

        public ReviewsInMemory(string hotelName)
            : base(hotelName)
        {
        }

        public override void AddOpinion(float opinion)
        {
            if (opinion >= 0 && opinion <= 5)
            {
                this.opinions.Add(opinion);

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

        public override void AddOpinion(string opinion)
        {
            if (float.TryParse(opinion, out float result))
            {
                var value = float.Parse(opinion);
                this.AddOpinion(value);
            }
            else
            {
                Console.WriteLine("String is not float");
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

            foreach (var opinion in this.opinions)
            {
                statistics.AddOpinion(opinion);
            }

            return statistics;
        }
    }
}
