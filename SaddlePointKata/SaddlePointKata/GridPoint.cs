namespace SaddlePointKata
{
    public class GridPoint
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Row + "," + Column + ":" + Value;
        }
    }

}