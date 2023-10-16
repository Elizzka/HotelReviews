namespace HotelReviews
{
    public class ReviewsInMemory : ReviewsBase
    {
        public override event OpinionAddedDelegate OpinionAdded;

        private List<float> opinions = new();

        public ReviewsInMemory(string hotelName)
            : base(hotelName)
        {
        }

        public override void AddOpinion(float opinion)
        {
            if (opinion >= 0 && opinion <= 5)
            {
                opinions.Add(opinion);

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
            var statistics = new Statistics();

            foreach (var opinion in this.opinions)
            {
                statistics.AddOpinion(opinion);
            }

            return statistics;
        }
    }
}
