namespace board
{
    class Position
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return Row + ", " + Column;
        }
    }
}
