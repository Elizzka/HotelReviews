namespace HotelReviews
{
    public interface IReviews
    {
        public delegate void OpinionAddedDelegate(object sender, EventArgs args);

        public string HotelName { get; }

        public void AddOpinion(float opinion);

        public void AddOpinion(string opinion);

        public void AddOpinion(char opinion);

        Statistics GetStatistics();
    }
}