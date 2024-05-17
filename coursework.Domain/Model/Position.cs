namespace coursework.Domain.Model
{
    public class Position
    {
        public int PositionId { get; set; }

        public string PositionTitle { get; set; }

        public int PositionBasePay { get; set; }

        public Position(int positionId, string positionTitle, int positionBasePay)
        {
            PositionId = positionId;
            PositionTitle = positionTitle;
            PositionBasePay = positionBasePay;
        }
    }
}
