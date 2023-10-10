namespace HotelReviews.Tests
{
    public class ReviewsTests
    {
        [Test]
        public void WhenGetStatisticsShouldReturnMinOpinion()
        {
            var reviews = new ReviewsInMemory("Hotel Per³a");
            reviews.AddOpinion(2);
            reviews.AddOpinion(1);
            reviews.AddOpinion(5);
            reviews.AddOpinion(3);

            var statistics = reviews.GetStatistics();

            Assert.AreEqual(1, statistics.Min);
        }

        [Test]
        public void WhenGetStatisticsShouldReturnMaxOpinion()
        {
            var reviews = new ReviewsInMemory("Hotel Per³a");
            reviews.AddOpinion(1);
            reviews.AddOpinion(4);
            reviews.AddOpinion(5);
            reviews.AddOpinion(2);

            var statistics = reviews.GetStatistics();

            Assert.AreEqual(5, statistics.Max);
        }

        [Test]
        public void WhenGetStatisticsShouldReturnAverageOpinion()
        {
            var reviews = new ReviewsInMemory("Hotel Per³a");
            reviews.AddOpinion(2);
            reviews.AddOpinion(4);
            reviews.AddOpinion(3);
            reviews.AddOpinion(5);

            var statistics = reviews.GetStatistics();

            Assert.AreEqual(3,5, statistics.Average);
        }

        [Test]
        public void WhenGetStatisticsShouldReturnAverageLetter()
        {
            var reviews = new ReviewsInMemory("Hotel Per³a");
            reviews.AddOpinion(5);
            reviews.AddOpinion(4);
            reviews.AddOpinion(2);
            reviews.AddOpinion(5);

            var statistics = reviews.GetStatistics();

            Assert.AreEqual('G', statistics.AverageLetter);
        }

        [Test]
        public void WhenGetStatisticsShouldReturnAverageLetter2()
        {
            var reviews = new ReviewsInMemory("Hotel Per³a");
            reviews.AddOpinion(1);
            reviews.AddOpinion(2);
            reviews.AddOpinion(3);
            reviews.AddOpinion(2);

            var statistics = reviews.GetStatistics();

            Assert.AreEqual('P', statistics.AverageLetter);
        }

    }
}