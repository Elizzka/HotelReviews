namespace HotelReviews
{
    public abstract class ReviewsBase : IReviews
    {
        public delegate void OpinionAddedDelegate(object sender, EventArgs args);

        public abstract event OpinionAddedDelegate OpinionAdded;

        public ReviewsBase(string hotelName)
        {
            this.HotelName = hotelName;
        }

        public string HotelName { get; private set; }

        public abstract void AddOpinion(float opinion);

        public void AddOpinion(string opinion)
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
                throw new Exception("String is not float");
            }
        }

        public void AddOpinion(char opinion)
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

        public abstract Statistics GetStatistics();
    }
}
