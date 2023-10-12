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

        public override void AddOpinion(string opinion)
        {
            if (float.TryParse(opinion, out float result))
            {
                this.AddOpinion(result);
            }
            else if (char.TryParse(opinion, out char CharResult))
            {
                this.AddOpinion(CharResult);
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
                    AddOpinion(5);
                    break;
                case 'G':
                    AddOpinion(4);
                    break;
                case 'A':
                    AddOpinion(3);
                    break;
                case 'P':
                    AddOpinion(2);
                    break;
                case 'N':
                    AddOpinion(1);
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
