namespace HotelReviews
{
    public class Statistics
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public float Sum { get; private set; }

        public int Count { get; private set; }

        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }

        }

        public char AverageLetter
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average >= 5 :
                        return 'E';
                    case var average when average >= 4:
                        return 'G';
                    case var average when average >= 3:
                        return 'A';
                    case var average when average >= 2:
                        return 'P';
                    default:
                        return 'N';
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }

        public void AddOpinion(float opinion)
        {
            this.Count++;
            this.Sum += opinion;
            this.Min = Math.Min(opinion, this.Min);
            this.Max = Math.Max(opinion, this.Max);
        }
    }
}
