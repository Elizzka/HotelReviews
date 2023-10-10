namespace HotelReviews
{
    public interface IReviews
    {
        public delegate void OpinionAddedDelegate(object sender, EventArgs args);

        public string HotelName { get; }

        public void AddOpinion(float grade);

        public void AddOpinion(string grade);

        public void AddOpinion(char grade);

        Statistics GetStatistics();
    }
}
