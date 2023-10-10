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

        public abstract void AddOpinion(float grade);

        public abstract void AddOpinion(string grade);

        public abstract void AddOpinion(char grade);

        public abstract Statistics GetStatistics();
    }
}
