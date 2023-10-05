namespace HotelReviews
{
    public interface IReviews
    {
        public string HotelName { get; }

        public void AddOpinion(float grade);

        public void AddOpinion(string grade);

        public void AddOpinion(char grade);

        Statistics GetStatistics();
    }
}
